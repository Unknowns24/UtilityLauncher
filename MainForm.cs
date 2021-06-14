using System;
using System.IO;
using System.Linq;
using System.Text;
using MaterialSkin;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace UtilityLauncher
{
    public partial class MainForm : MaterialForm
    {
        Random rnd = new Random();
        MaterialSkinManager materialSkinManager;

        private string userEncryptPassword = "";

        private string HeidiPath = "";
        private string PuttyPath = "";
        private string WinScpPath = "";
        private string FilezillaPath = "";

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

        private Dictionary<string, string> AccountEncrypt(string aname, string apass, string auser)
        {
            var keyValues = new Dictionary<string, string> // Se crea un diccionario donde se pondra una structura Key Value para ser codificada a Json
            {
                { "name", aname },
                { "username", auser },
                { "password", apass }
            };

            string json = DictionaryToJson(keyValues);

            string password = MD5Hash(userEncryptPassword.Substring(0, 16) + userEncryptPassword.ToString() + userEncryptPassword.Substring(16));

            // Create sha256 hash
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(MD5Hash(password)));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            string encrypted = Aes_Encrypt(json, key, iv);

            keyValues.Add("encryptedData", encrypted);

            return keyValues;
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

                Dictionary<string, string> AccountInfo = jsonToDictionary(decrypt);

                Account tempData = new Account { index = (accounts.Count + 1).ToString(), name = AccountInfo["name"], username = AccountInfo["username"], password = AccountInfo["password"], path = filePath};

                accounts.Add(tempData);
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(-1);
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
        public string username { get; set; }
        public string password { get; set; }
        public string port { get; set; }
        
        // Apps
        public bool putty { get; set; }
        public bool heidi { get; set; }
        public bool winscp { get; set; }
        public bool filezilla { get; set; }
    }
}
