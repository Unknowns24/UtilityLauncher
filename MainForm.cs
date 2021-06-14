using System;
using System.IO;
using System.Linq;
using System.Text;
using MaterialSkin;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace UtilityLauncher
{
    public partial class MainForm : MaterialForm
    {
        Random rnd = new Random();
        Account thisAccount = null;
        MaterialSkinManager materialSkinManager;

        private string userEncryptPassword = "";

        private string HeidiPath = "";
        private string PuttyPath = "";
        private string WinScpPath = "";
        private string FilezillaPath = "";

        private bool isEditing = false;
        private bool showPassword = false;

        private List<Account> accounts = new List<Account>();

        public MainForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow700, Primary.Yellow800, Primary.Yellow500, Accent.Yellow400, TextShade.WHITE);

            rb_putty.Enabled = false;
            rb_heidi.Enabled = false;
            rb_winscp.Enabled = false;
            rb_filezilla.Enabled = false;

            txt_port.Visible = false;
            comb_accounts.Width = 602;


            txt_pass.Password = true;

            comb_accounts.Items.Add("Select an account");
            comb_accounts.SelectedItem = "Select an account";

            loadConfig();
            loadAccounts();
        }

        private void loadAccounts()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "/data";

            if (Directory.Exists(basePath))
            {
                foreach (var fileName in Directory.GetFiles(basePath, "*"))
                {
                    AccountDecrypt(File.ReadAllText(fileName), fileName);
                }
            }
        }

        private void loadConfig()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "/other.ulfs";

            if (File.Exists(basePath))
            {
                try
                {
                    string password = MD5Hash(GetMacAdress());

                    // Create sha256 hash
                    SHA256 mySHA256 = SHA256Managed.Create();
                    byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

                    // Create secret IV
                    byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

                    string decrypt = Aes_Decrypt(File.ReadAllText(basePath), key, iv);

                    Dictionary<string, string> Settings = jsonToDictionary(decrypt);
                    
                    userEncryptPassword = Settings["userEncryptPassword"];

                    HeidiPath = Settings["HeidiPath"];
                    PuttyPath = Settings["PuttyPath"];
                    WinScpPath = Settings["WinScpPath"];
                    FilezillaPath = Settings["FilezillaPath"];

                    txt_filesPass.Text = userEncryptPassword;
                    txt_filesPass.Enabled = false;

                    txt_heidiPath.Text = HeidiPath;
                    txt_puttyPath.Text = PuttyPath;
                    txt_winscpPath.Text = WinScpPath;
                    txt_filezillaPath.Text = FilezillaPath;
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.ToString(), "Parse file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Error while tring to read saved settings", "Parse file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_filesPass.Text = "";
                    txt_puttyPath.Text = "";
                    txt_heidiPath.Text = "";
                    txt_winscpPath.Text = "";
                    txt_filezillaPath.Text = "";
                }
            }
            else
            {
                txt_filesPass.Text = "";
                txt_puttyPath.Text = "";
                txt_heidiPath.Text = "";
                txt_winscpPath.Text = "";
                txt_filezillaPath.Text = "";
            }
        }


        //////////////////////////
        // Dictionary Functions //
        /////////////////////////

        public string DictionaryToJson(Dictionary<string, string> dictionary)
        {
            var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, kvp.Value));
            return string.Concat("{", string.Join(",", kvs), "}");
        }

        public Dictionary<string, string> jsonToDictionary(string json)
        {
            string[] keyValueArray = json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
            return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Substring(item.Split(':')[0].Length + 1));
        }

        /////////////////////////
        // Encryptation System //
        /////////////////////////

        private void AccountEncrypt(string AccountHost, string AccountName, string AccountUser, string AccountPassword, bool ssh, bool ftp, bool sftp, bool sql)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory + "/data";

                if (!AccountName.Contains($"{AccountUser}@{AccountHost}"))
                {
                    AccountName = AccountName + $" ({AccountUser}@{AccountHost})";
                }

                for (int i = 0; i < 9999; i++)
                {
                    if (File.Exists($"{basePath}/{AccountName}.ulfs"))
                    {
                        AccountName = $"[0{i}] " + AccountName;
                    }
                    else
                    {
                        break;
                    }
                }

                var keyValues = new Dictionary<string, string> // Se crea un diccionario donde se pondra una structura Key Value para ser codificada a Json
                {
                    {"AccountHost", AccountHost},
                    {"AccountName", AccountName},
                    {"AccountUser", AccountUser},
                    {"AccountPassword", AccountPassword},
                    {"ssh", ssh.ToString()},
                    {"ftp", ftp.ToString()},
                    {"sftp", sftp.ToString()},
                    {"sql", sql.ToString()}
                };

                string json = DictionaryToJson(keyValues);

                string password = MD5Hash(userEncryptPassword.Substring(0, 16) + userEncryptPassword.ToString() + userEncryptPassword.Substring(16));

                // Create sha256 hash
                SHA256 mySHA256 = SHA256Managed.Create();
                byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(MD5Hash(password)));

                // Create secret IV
                byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

                string encrypted = Aes_Encrypt(json, key, iv);

                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                File.WriteAllText(Path.GetFullPath($"{basePath}/{AccountName}.ulfs"), encrypted);

                Account tempData = new Account
                {
                    index = (accounts.Count + 1).ToString(),
                    path = $"{basePath}/{AccountName}.ulfs",

                    name = keyValues["AccountName"],
                    host = keyValues["AccountHost"],
                    username = keyValues["AccountUser"],
                    password = keyValues["AccountPassword"],

                    putty = ssh,
                    heidi = sql,
                    winscp = sftp,
                    filezilla = ftp
                };

                accounts.Add(tempData);
                comb_accounts.Items.Add(AccountName);

                MessageBox.Show("Account Saved", "Information saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                chk_ssh.Checked = false;
                chk_ftp.Checked = false;
                chk_sftp.Checked = false;
                chk_mysql.Checked = false;

                showPassword = false;
                txt_pass.Password = true;

                txt_name.Text = "";
                txt_user.Text = "";
                txt_pass.Text = "";
                txt_host.Text = "";
            }
            catch(Exception err)
            {
                MessageBox.Show("An error occurred while saving account data\n\nError:"+err.Message, "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        

        private void AccountDecrypt(string AES, string filePath)
        {
            try
            {
                string password = MD5Hash(userEncryptPassword.Substring(0, 16) + userEncryptPassword.ToString() + userEncryptPassword.Substring(16));

                // Create sha256 hash
                SHA256 mySHA256 = SHA256Managed.Create();
                byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(MD5Hash(password)));

                // Create secret IV
                byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

                string decrypt = Aes_Decrypt(AES, key, iv);

                Dictionary<string, string> keyValues = jsonToDictionary(decrypt);

                Account tempData = new Account
                {
                    index = (accounts.Count + 1).ToString(),
                    path = filePath,

                    name = keyValues["AccountName"],
                    host = keyValues["AccountHost"],
                    username = keyValues["AccountUser"],
                    password = keyValues["AccountPassword"],

                    putty = bool.Parse(keyValues["ssh"]),
                    heidi = bool.Parse(keyValues["sql"]),
                    winscp = bool.Parse(keyValues["sftp"]),
                    filezilla = bool.Parse(keyValues["ftp"])
                };

                accounts.Add(tempData);
                comb_accounts.Items.Add(keyValues["AccountName"]);
            }
            catch
            {
                //
            }
        }

        ///////////////////////////
        // Encryptation Function //
        ///////////////////////////

        public string Aes_Encrypt(string plainText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherText;
        }

        public string Aes_Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key;
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;

            try
            {
                // Convert the ciphertext string into a byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                byte[] plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainText;
        }

        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        /////////////////////
        // Other Functions //
        /////////////////////

        public string GetMacAdress()
        {
            string mac = "NULL";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        mac = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }

            return mac;
        }

        private void SaveSettings()
        {
            string mac = GetMacAdress();

            if (mac == "NULL")
            {
                MessageBox.Show("An error ocurred while trying to get the Mac Adress", "Mac Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var keyValues = new Dictionary<string, string> // Se crea un diccionario donde se pondra una structura Key Value para ser codificada a Json
            {
                { "userEncryptPassword", MD5Hash(txt_filesPass.Text) },
                { "HeidiPath",  txt_heidiPath.Text},
                { "PuttyPath",  txt_puttyPath.Text},
                { "WinScpPath",  txt_winscpPath.Text},
                { "FilezillaPath",  txt_filezillaPath.Text}
            };

            string json = DictionaryToJson(keyValues);

            string password = MD5Hash(mac);

            // Create sha256 hash
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            string encrypted = Aes_Encrypt(json, key, iv);

            string basePath = AppDomain.CurrentDomain.BaseDirectory + "/other.ulfs";

            File.WriteAllText(basePath, encrypted);
        }

        //////////////////
        // Apps Install //
        //////////////////

        private void btn_filezillaInstall_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://filezilla-project.org/");
        }

        private void btn_winscpInstall_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://winscp.net/eng/download.php");
        }

        private void btn_puttyInstall_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.chiark.greenend.org.uk/~sgtatham/putty/latest.html");
        }

        private void btn_heidiInstall_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.heidisql.com/download.php?download=installer");
        }

        /////////////////
        // Search Apps //
        /////////////////

        private void btn_filezillaSearch_Click(object sender, EventArgs e)
        {
            ofd_searchApps.Title = "Open Filezilla executable";
            ofd_searchApps.FileName = "filezilla.exe";
            ofd_searchApps.ShowDialog();
            string path = ofd_searchApps.FileName;

            if (Path.GetFileName(path) == "filezilla.exe")
            {
                if (File.ReadAllText(path).Contains("MZ"))
                {
                    txt_filezillaPath.Text = path;
                }
                else
                {
                    MessageBox.Show("Please, Select a valid filezilla executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please, Select a valid filezilla executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_winscpSearch_Click(object sender, EventArgs e)
        {
            ofd_searchApps.Title = "Open WinSCP executable";
            ofd_searchApps.FileName = "WinSCP.exe";
            ofd_searchApps.ShowDialog();
            string path = ofd_searchApps.FileName;

            if (Path.GetFileName(path) == "WinSCP.exe")
            {
                if (File.ReadAllText(path).Contains("MZ"))
                {
                    txt_winscpPath.Text = path;
                }
                else
                {
                    MessageBox.Show("Please, Select a valid WinSCP executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please, Select a valid WinSCP executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_puttySearch_Click(object sender, EventArgs e)
        {
            ofd_searchApps.Title = "Open Putty executable";
            ofd_searchApps.FileName = "putty.exe";
            ofd_searchApps.ShowDialog();
            string path = ofd_searchApps.FileName;

            if (Path.GetFileName(path) == "putty.exe")
            {
                if (File.ReadAllText(path).Contains("MZ"))
                {
                    txt_puttyPath.Text = path;
                }
                else
                {
                    MessageBox.Show("Please, Select a valid Putty executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please, Select a valid Putty executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_heidiSearch_Click(object sender, EventArgs e)
        {
            ofd_searchApps.Title = "Open HeidiSQL executable";
            ofd_searchApps.FileName = "heidisql.exe";
            ofd_searchApps.ShowDialog();
            string path = ofd_searchApps.FileName;

            if (Path.GetFileName(path) == "heidisql.exe")
            {
                if (File.ReadAllText(path).Contains("MZ"))
                {
                    txt_heidiPath.Text = path;
                }
                else
                {
                    MessageBox.Show("Please, Select a valid HeidiSQL executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please, Select a valid HeidiSQL executable.", "Invalid Program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //////////////////////
        // Settings Buttons //
        //////////////////////

        private void btn_cfg_cancel_Click(object sender, EventArgs e)
        {
            if ((userEncryptPassword != "" && userEncryptPassword != " ") 
                || (HeidiPath != "" && HeidiPath != " ") 
                || (PuttyPath != "" && PuttyPath != " ") 
                || (WinScpPath != "" && WinScpPath != " ")
                || (FilezillaPath != "" && FilezillaPath != " "))
            {
                txt_filesPass.Text = userEncryptPassword;
                txt_heidiPath.Text = HeidiPath;
                txt_puttyPath.Text = PuttyPath;
                txt_winscpPath.Text = WinScpPath;
                txt_filezillaPath.Text = FilezillaPath;
            }
            else
            {
                txt_filesPass.Text = "";
                txt_puttyPath.Text = "";
                txt_heidiPath.Text = "";
                txt_winscpPath.Text = "";
                txt_filezillaPath.Text = "";
            }
        }

        private void btn_cfg_save_Click(object sender, EventArgs e)
        {
            if (txt_filesPass.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("You can't set an empty password for the files", "Invalid Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string basePath = AppDomain.CurrentDomain.BaseDirectory + "/other.ulfs";

            if (File.Exists(basePath))
            {
                DialogResult answer = MessageBox.Show("Your old settings will be rewritten if you continue, Do you want to continue?", "Existing Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    SaveSettings();
                }
            }
            else
            {
                SaveSettings();
            }

            MessageBox.Show("Setting saved successfully", "Settings Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadConfig();
        }

        ////////////////////
        // Debug Function //
        ////////////////////

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(-1);
        }

        ///////////////////////////////
        // Account Creator Functions //
        ///////////////////////////////

        private void btn_swithPass_Click(object sender, EventArgs e)
        {
            txt_pass.Focus();

            if (showPassword == true)
            {
                txt_pass.Focus();
                txt_pass.Password = true;
            }
            else
            {
                txt_pass.Focus();
                txt_pass.Password = false;
            }
            
            showPassword = !showPassword;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                isEditing = false;
                btn_clear.Text = "Clear";
                btn_add_update.Text = "Add";

                btn_clear.Left = 565;
                btn_add_update.Left = 640;
                btn_add_update.Width = 50;
            }

            rb_putty.Checked = false;
            rb_heidi.Checked = false;
            rb_winscp.Checked = false;
            rb_filezilla.Checked = false;

            comb_accounts.SelectedItem = "Select an account";

            chk_ssh.Checked = false;
            chk_ftp.Checked = false;
            chk_sftp.Checked = false;
            chk_mysql.Checked = false;

            showPassword = false;
            txt_pass.Password = true;

            txt_name.Text = "";
            txt_user.Text = "";
            txt_pass.Text = "";
            txt_host.Text = "";
        }

        private void btn_add_update_Click(object sender, EventArgs e)
        {
            if (userEncryptPassword == "" || userEncryptPassword == null)
            {
                MessageBox.Show("You need to set a password in the configs before save an account", "No password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_host.Text.Replace(" ", "") == "" || txt_name.Text.Replace(" ", "") == "" || txt_user.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("There are empty fields, Please complete all fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chk_ssh.Checked == false && chk_ftp.Checked == false && chk_sftp.Checked == false && chk_mysql.Checked == false)
            {
                MessageBox.Show("You need to select the available connect methods for this new account", "No methods selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditing == true)
            {
                DialogResult res = MessageBox.Show($"Are you sure do you want to update \"{thisAccount.name}\" Account?", "Update account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res != DialogResult.Yes)
                {
                    return;
                }

                comb_accounts.Items.Remove(thisAccount.name);

                if (File.Exists(thisAccount.path))
                {
                    File.Delete(thisAccount.path);
                }

                accounts.Remove(thisAccount);

                thisAccount = null;

                AccountEncrypt(txt_host.Text, txt_name.Text, txt_user.Text, txt_pass.Text, chk_ssh.Checked, chk_ftp.Checked, chk_sftp.Checked, chk_mysql.Checked);

                comb_accounts.SelectedItem = "Select an account";

                isEditing = false;
                btn_clear.Text = "Clear";
                btn_add_update.Text = "Add";

                btn_clear.Left = 565;
                btn_add_update.Left = 640;
                btn_add_update.Width = 50;
            }
            else
            {
                AccountEncrypt(txt_host.Text, txt_name.Text, txt_user.Text, txt_pass.Text, chk_ssh.Checked, chk_ftp.Checked, chk_sftp.Checked, chk_mysql.Checked);
            }
        }

        private void comb_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            rb_putty.Checked = false;
            rb_heidi.Checked = false;
            rb_winscp.Checked = false;
            rb_filezilla.Checked = false;

            if (comb_accounts.SelectedItem.ToString() == "Select an account")
            {
                txt_port.Visible = false;
                comb_accounts.Width = 602;

                rb_putty.Enabled = false;
                rb_heidi.Enabled = false;
                rb_winscp.Enabled = false;
                rb_filezilla.Enabled = false;

                btn_open.Enabled = false;
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;

                thisAccount = null;

                return;
            }

            btn_open.Enabled = false;
            btn_edit.Enabled = true;
            btn_delete.Enabled = true;

            txt_port.Visible = true;
            comb_accounts.Width = 505;

            bool finded = false;

            foreach (var account in accounts)
            {
                if (account.name == comb_accounts.SelectedItem.ToString())
                {
                    finded = true;
                    thisAccount = account;
                    break;
                }
            }

            if (finded && thisAccount != null)
            {
                rb_putty.Enabled = thisAccount.putty;
                rb_heidi.Enabled = thisAccount.heidi;
                rb_winscp.Enabled = thisAccount.winscp;
                rb_filezilla.Enabled = thisAccount.filezilla;
            }
        }

        ///////////////////
        // Radio Buttons //
        ///////////////////

        private void rb_putty_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_putty.Checked == true)
            {
                btn_open.Enabled = true;
                txt_port.Text = "22";
            }
        }

        private void rb_filezilla_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_filezilla.Checked == true)
            {
                btn_open.Enabled = true;
                txt_port.Text = "21";
            }
        }

        private void rb_winscp_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_winscp.Checked == true)
            {
                btn_open.Enabled = true;
                txt_port.Text = "22";
            }
        }

        private void rb_heidi_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_heidi.Checked == true)
            {
                btn_open.Enabled = true;
                txt_port.Text = "3306";
            }
        }

        /////////////////////////////
        // Account Creator Manager //
        /////////////////////////////

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (comb_accounts.SelectedItem.ToString() == "Select an account")
            {
                return;
            }

            if (txt_port.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("There are empty fields, Please complete all fields", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rb_putty.Checked == false && rb_filezilla.Checked == false && rb_winscp.Checked == false && rb_heidi.Checked == false)
            {
                MessageBox.Show("You need to select the connect method", "No method selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string Port = txt_port.Text;

            Thread OpenThread = new Thread(() =>
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                
                if (rb_putty.Checked)
                {
                    if (PuttyPath == "" || PuttyPath == null)
                    {
                        MessageBox.Show("Please, Set the putty.exe path in the configuration", "No Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    startInfo.FileName = PuttyPath;
                    startInfo.Arguments = string.Format("{0}@{1} -pw {2} -P {3}", thisAccount.username, thisAccount.host, thisAccount.password, Port);
                }

                if (rb_filezilla.Checked)
                {
                    if (FilezillaPath == "" || FilezillaPath == null)
                    {
                        MessageBox.Show("Please, Set the filezilla.exe path in the configuration", "No Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    startInfo.FileName = FilezillaPath;
                    startInfo.Arguments = string.Format("ftp://{0}:{1}@{2}:{3}", thisAccount.username, thisAccount.password, thisAccount.host, Port);
                }

                if (rb_winscp.Checked)
                {
                    if (WinScpPath == "" || WinScpPath == null)
                    {
                        MessageBox.Show("Please, Set the WinSCP.exe path in the configuration", "No Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    startInfo.FileName = WinScpPath;
                    startInfo.Arguments = string.Format("sftp://{0}:{1}@{2}:{3}", thisAccount.username, thisAccount.password, thisAccount.host, Port);
                }

                if (rb_heidi.Checked)
                {
                    if (HeidiPath == "" || HeidiPath == null)
                    {
                        MessageBox.Show("Please, Set the heidisql.exe path in the configuration", "No Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    startInfo.FileName = HeidiPath;
                    startInfo.Arguments = string.Format("--host={0} --user={1} --password={2} --port={3}", thisAccount.host, thisAccount.username, thisAccount.password, Port);
                }

                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
            });

            OpenThread.Start();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (comb_accounts.SelectedItem.ToString() == "Select an account")
            {
                return;
            }

            DialogResult res = MessageBox.Show($"Do you want to delete the account: \"{thisAccount.name}\"", "Delete account!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                comb_accounts.Items.Remove(thisAccount.name);

                if(File.Exists(thisAccount.path))
                {
                    File.Delete(thisAccount.path);
                }

                accounts.Remove(thisAccount);

                thisAccount = null;

                comb_accounts.SelectedItem = "Select an account";
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (comb_accounts.SelectedItem.ToString() == "Select an account")
            {
                return;
            }

            isEditing = true;

            btn_clear.Text = "Cancel";
            btn_add_update.Text = "Update";
            btn_add_update.Width = 60;

            btn_clear.Left = 540;
            btn_add_update.Left = 620;

            txt_name.Text = thisAccount.name;
            txt_host.Text = thisAccount.host;
            txt_user.Text = thisAccount.username;
            txt_pass.Text = thisAccount.password;

            chk_ssh.Checked = thisAccount.putty;
            chk_ftp.Checked = thisAccount.filezilla;
            chk_sftp.Checked = thisAccount.winscp;
            chk_mysql.Checked = thisAccount.heidi;
        }
    }


    ///////////////////
    // Acounts class //
    ///////////////////

    public class Account
    {
        // IDs
        public string index { get; set; }
        public string path { get; set; }

        // Account Info
        public string name { get; set; }
        public string host { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        // Apps
        public bool putty { get; set; }
        public bool heidi { get; set; }
        public bool winscp { get; set; }
        public bool filezilla { get; set; }
    }
}
