
namespace UtilityLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxContextMenuStrip1 = new MaterialSkin.Controls.TextBoxContextMenuStrip();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.txt_host = new MaterialSkin.Controls.MaterialTextBox();
            this.btn_swithPass = new MaterialSkin.Controls.MaterialButton();
            this.chk_mysql = new MaterialSkin.Controls.MaterialCheckbox();
            this.chk_sftp = new MaterialSkin.Controls.MaterialCheckbox();
            this.chk_ftp = new MaterialSkin.Controls.MaterialCheckbox();
            this.chk_ssh = new MaterialSkin.Controls.MaterialCheckbox();
            this.txt_pass = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_user = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_name = new MaterialSkin.Controls.MaterialTextBox();
            this.btn_clear = new MaterialSkin.Controls.MaterialButton();
            this.btn_add_update = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txt_port = new MaterialSkin.Controls.MaterialTextBox();
            this.btn_delete = new MaterialSkin.Controls.MaterialButton();
            this.btn_edit = new MaterialSkin.Controls.MaterialButton();
            this.btn_open = new MaterialSkin.Controls.MaterialButton();
            this.rb_heidi = new MaterialSkin.Controls.MaterialRadioButton();
            this.rb_filezilla = new MaterialSkin.Controls.MaterialRadioButton();
            this.rb_winscp = new MaterialSkin.Controls.MaterialRadioButton();
            this.rb_putty = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbl_account = new MaterialSkin.Controls.MaterialLabel();
            this.comb_accounts = new MaterialSkin.Controls.MaterialComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_filezillaSearch = new MaterialSkin.Controls.MaterialButton();
            this.btn_winscpSearch = new MaterialSkin.Controls.MaterialButton();
            this.btn_puttySearch = new MaterialSkin.Controls.MaterialButton();
            this.btn_heidiSearch = new MaterialSkin.Controls.MaterialButton();
            this.btn_cfg_cancel = new MaterialSkin.Controls.MaterialButton();
            this.btn_cfg_save = new MaterialSkin.Controls.MaterialButton();
            this.btn_heidiInstall = new MaterialSkin.Controls.MaterialButton();
            this.btn_puttyInstall = new MaterialSkin.Controls.MaterialButton();
            this.btn_winscpInstall = new MaterialSkin.Controls.MaterialButton();
            this.btn_filezillaInstall = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_heidiPath = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_puttyPath = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_winscpPath = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_filezillaPath = new MaterialSkin.Controls.MaterialLabel();
            this.txt_heidiPath = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_filesPass = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_winscpPath = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_puttyPath = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_filezillaPath = new MaterialSkin.Controls.MaterialTextBox();
            this.img_list_icons = new System.Windows.Forms.ImageList(this.components);
            this.ofd_searchApps = new System.Windows.Forms.OpenFileDialog();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxContextMenuStrip1
            // 
            this.textBoxContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.textBoxContextMenuStrip1.Depth = 0;
            this.textBoxContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxContextMenuStrip1.Name = "textBoxContextMenuStrip1";
            this.textBoxContextMenuStrip1.Size = new System.Drawing.Size(123, 160);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.img_list_icons;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(805, 603);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.materialCard2);
            this.tabPage1.Controls.Add(this.materialCard1);
            this.tabPage1.ImageKey = "dashboard.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(797, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.txt_host);
            this.materialCard2.Controls.Add(this.btn_swithPass);
            this.materialCard2.Controls.Add(this.chk_mysql);
            this.materialCard2.Controls.Add(this.chk_sftp);
            this.materialCard2.Controls.Add(this.chk_ftp);
            this.materialCard2.Controls.Add(this.chk_ssh);
            this.materialCard2.Controls.Add(this.txt_pass);
            this.materialCard2.Controls.Add(this.txt_user);
            this.materialCard2.Controls.Add(this.txt_name);
            this.materialCard2.Controls.Add(this.btn_clear);
            this.materialCard2.Controls.Add(this.btn_add_update);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(19, 212);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(708, 312);
            this.materialCard2.TabIndex = 19;
            // 
            // txt_host
            // 
            this.txt_host.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_host.Depth = 0;
            this.txt_host.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_host.Hint = "Host";
            this.txt_host.Location = new System.Drawing.Point(361, 87);
            this.txt_host.MaxLength = 50;
            this.txt_host.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_host.Multiline = false;
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(295, 50);
            this.txt_host.TabIndex = 31;
            this.txt_host.Text = "";
            // 
            // btn_swithPass
            // 
            this.btn_swithPass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_swithPass.Depth = 0;
            this.btn_swithPass.DrawShadows = true;
            this.btn_swithPass.HighEmphasis = true;
            this.btn_swithPass.Icon = null;
            this.btn_swithPass.Location = new System.Drawing.Point(492, 160);
            this.btn_swithPass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_swithPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_swithPass.Name = "btn_swithPass";
            this.btn_swithPass.Size = new System.Drawing.Size(157, 36);
            this.btn_swithPass.TabIndex = 29;
            this.btn_swithPass.Text = "Reveal Password";
            this.btn_swithPass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btn_swithPass.UseAccentColor = false;
            this.btn_swithPass.UseVisualStyleBackColor = true;
            this.btn_swithPass.Click += new System.EventHandler(this.btn_swithPass_Click);
            // 
            // chk_mysql
            // 
            this.chk_mysql.AutoSize = true;
            this.chk_mysql.Depth = 0;
            this.chk_mysql.Location = new System.Drawing.Point(481, 208);
            this.chk_mysql.Margin = new System.Windows.Forms.Padding(0);
            this.chk_mysql.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chk_mysql.MouseState = MaterialSkin.MouseState.HOVER;
            this.chk_mysql.Name = "chk_mysql";
            this.chk_mysql.Ripple = true;
            this.chk_mysql.Size = new System.Drawing.Size(168, 37);
            this.chk_mysql.TabIndex = 28;
            this.chk_mysql.Text = "HeidiSQL (MySQL)";
            this.chk_mysql.UseVisualStyleBackColor = true;
            // 
            // chk_sftp
            // 
            this.chk_sftp.AutoSize = true;
            this.chk_sftp.Depth = 0;
            this.chk_sftp.Location = new System.Drawing.Point(324, 208);
            this.chk_sftp.Margin = new System.Windows.Forms.Padding(0);
            this.chk_sftp.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chk_sftp.MouseState = MaterialSkin.MouseState.HOVER;
            this.chk_sftp.Name = "chk_sftp";
            this.chk_sftp.Ripple = true;
            this.chk_sftp.Size = new System.Drawing.Size(146, 37);
            this.chk_sftp.TabIndex = 27;
            this.chk_sftp.Text = "WinSCP (SFTP)";
            this.chk_sftp.UseVisualStyleBackColor = true;
            // 
            // chk_ftp
            // 
            this.chk_ftp.AutoSize = true;
            this.chk_ftp.Depth = 0;
            this.chk_ftp.Location = new System.Drawing.Point(181, 208);
            this.chk_ftp.Margin = new System.Windows.Forms.Padding(0);
            this.chk_ftp.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chk_ftp.MouseState = MaterialSkin.MouseState.HOVER;
            this.chk_ftp.Name = "chk_ftp";
            this.chk_ftp.Ripple = true;
            this.chk_ftp.Size = new System.Drawing.Size(133, 37);
            this.chk_ftp.TabIndex = 26;
            this.chk_ftp.Text = "Filezilla (FTP)";
            this.chk_ftp.UseVisualStyleBackColor = true;
            // 
            // chk_ssh
            // 
            this.chk_ssh.AutoSize = true;
            this.chk_ssh.Depth = 0;
            this.chk_ssh.Location = new System.Drawing.Point(54, 208);
            this.chk_ssh.Margin = new System.Windows.Forms.Padding(0);
            this.chk_ssh.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chk_ssh.MouseState = MaterialSkin.MouseState.HOVER;
            this.chk_ssh.Name = "chk_ssh";
            this.chk_ssh.Ripple = true;
            this.chk_ssh.Size = new System.Drawing.Size(118, 37);
            this.chk_ssh.TabIndex = 25;
            this.chk_ssh.Text = "Putty (SSH)";
            this.chk_ssh.UseVisualStyleBackColor = true;
            // 
            // txt_pass
            // 
            this.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pass.Depth = 0;
            this.txt_pass.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_pass.Hint = "Password";
            this.txt_pass.Location = new System.Drawing.Point(54, 153);
            this.txt_pass.MaxLength = 50;
            this.txt_pass.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_pass.Multiline = false;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(421, 50);
            this.txt_pass.TabIndex = 23;
            this.txt_pass.Text = "";
            // 
            // txt_user
            // 
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_user.Depth = 0;
            this.txt_user.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_user.Hint = "User";
            this.txt_user.Location = new System.Drawing.Point(53, 87);
            this.txt_user.MaxLength = 50;
            this.txt_user.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_user.Multiline = false;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(295, 50);
            this.txt_user.TabIndex = 21;
            this.txt_user.Text = "";
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_name.Depth = 0;
            this.txt_name.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_name.Hint = "Account Name";
            this.txt_name.Location = new System.Drawing.Point(54, 26);
            this.txt_name.MaxLength = 50;
            this.txt_name.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_name.Multiline = false;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(602, 50);
            this.txt_name.TabIndex = 20;
            this.txt_name.Text = "";
            // 
            // btn_clear
            // 
            this.btn_clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_clear.Depth = 0;
            this.btn_clear.DrawShadows = true;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.HighEmphasis = true;
            this.btn_clear.Icon = null;
            this.btn_clear.Location = new System.Drawing.Point(565, 265);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_clear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(66, 36);
            this.btn_clear.TabIndex = 19;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_clear.UseAccentColor = false;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_add_update
            // 
            this.btn_add_update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_add_update.Depth = 0;
            this.btn_add_update.DrawShadows = true;
            this.btn_add_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_update.HighEmphasis = true;
            this.btn_add_update.Icon = null;
            this.btn_add_update.Location = new System.Drawing.Point(640, 265);
            this.btn_add_update.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_add_update.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_add_update.Name = "btn_add_update";
            this.btn_add_update.Size = new System.Drawing.Size(50, 36);
            this.btn_add_update.TabIndex = 18;
            this.btn_add_update.Text = "Add";
            this.btn_add_update.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_add_update.UseAccentColor = false;
            this.btn_add_update.UseVisualStyleBackColor = true;
            this.btn_add_update.Click += new System.EventHandler(this.btn_add_update_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txt_port);
            this.materialCard1.Controls.Add(this.btn_delete);
            this.materialCard1.Controls.Add(this.btn_edit);
            this.materialCard1.Controls.Add(this.btn_open);
            this.materialCard1.Controls.Add(this.rb_heidi);
            this.materialCard1.Controls.Add(this.rb_filezilla);
            this.materialCard1.Controls.Add(this.rb_winscp);
            this.materialCard1.Controls.Add(this.rb_putty);
            this.materialCard1.Controls.Add(this.lbl_account);
            this.materialCard1.Controls.Add(this.comb_accounts);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(19, 17);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(708, 185);
            this.materialCard1.TabIndex = 1;
            // 
            // txt_port
            // 
            this.txt_port.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_port.Depth = 0;
            this.txt_port.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_port.Hint = "Port";
            this.txt_port.Location = new System.Drawing.Point(565, 39);
            this.txt_port.MaxLength = 50;
            this.txt_port.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_port.Multiline = false;
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(94, 50);
            this.txt_port.TabIndex = 32;
            this.txt_port.Text = "";
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_delete.Depth = 0;
            this.btn_delete.DrawShadows = true;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.HighEmphasis = true;
            this.btn_delete.Icon = null;
            this.btn_delete.Location = new System.Drawing.Point(460, 139);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_delete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(73, 36);
            this.btn_delete.TabIndex = 18;
            this.btn_delete.Text = "Delete";
            this.btn_delete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_delete.UseAccentColor = false;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_edit.Depth = 0;
            this.btn_edit.DrawShadows = true;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.HighEmphasis = true;
            this.btn_edit.Icon = null;
            this.btn_edit.Location = new System.Drawing.Point(555, 139);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_edit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(53, 36);
            this.btn_edit.TabIndex = 17;
            this.btn_edit.Text = "Edit";
            this.btn_edit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_edit.UseAccentColor = false;
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_open
            // 
            this.btn_open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_open.Depth = 0;
            this.btn_open.DrawShadows = true;
            this.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open.HighEmphasis = true;
            this.btn_open.Icon = null;
            this.btn_open.Location = new System.Drawing.Point(630, 139);
            this.btn_open.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_open.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(60, 36);
            this.btn_open.TabIndex = 16;
            this.btn_open.Text = "Open";
            this.btn_open.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_open.UseAccentColor = false;
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // rb_heidi
            // 
            this.rb_heidi.AutoSize = true;
            this.rb_heidi.Depth = 0;
            this.rb_heidi.Location = new System.Drawing.Point(526, 96);
            this.rb_heidi.Margin = new System.Windows.Forms.Padding(0);
            this.rb_heidi.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_heidi.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_heidi.Name = "rb_heidi";
            this.rb_heidi.Ripple = true;
            this.rb_heidi.Size = new System.Drawing.Size(101, 37);
            this.rb_heidi.TabIndex = 5;
            this.rb_heidi.TabStop = true;
            this.rb_heidi.Text = "HeidiSQL";
            this.rb_heidi.UseVisualStyleBackColor = true;
            this.rb_heidi.CheckedChanged += new System.EventHandler(this.rb_heidi_CheckedChanged);
            // 
            // rb_filezilla
            // 
            this.rb_filezilla.AutoSize = true;
            this.rb_filezilla.Depth = 0;
            this.rb_filezilla.Location = new System.Drawing.Point(210, 96);
            this.rb_filezilla.Margin = new System.Windows.Forms.Padding(0);
            this.rb_filezilla.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_filezilla.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_filezilla.Name = "rb_filezilla";
            this.rb_filezilla.Ripple = true;
            this.rb_filezilla.Size = new System.Drawing.Size(133, 37);
            this.rb_filezilla.TabIndex = 4;
            this.rb_filezilla.TabStop = true;
            this.rb_filezilla.Text = "Filezilla (FTP)";
            this.rb_filezilla.UseVisualStyleBackColor = true;
            this.rb_filezilla.CheckedChanged += new System.EventHandler(this.rb_filezilla_CheckedChanged);
            // 
            // rb_winscp
            // 
            this.rb_winscp.AutoSize = true;
            this.rb_winscp.Depth = 0;
            this.rb_winscp.Location = new System.Drawing.Point(364, 96);
            this.rb_winscp.Margin = new System.Windows.Forms.Padding(0);
            this.rb_winscp.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_winscp.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_winscp.Name = "rb_winscp";
            this.rb_winscp.Ripple = true;
            this.rb_winscp.Size = new System.Drawing.Size(146, 37);
            this.rb_winscp.TabIndex = 3;
            this.rb_winscp.TabStop = true;
            this.rb_winscp.Text = "WinSCP (SFTP)";
            this.rb_winscp.UseVisualStyleBackColor = true;
            this.rb_winscp.CheckedChanged += new System.EventHandler(this.rb_winscp_CheckedChanged);
            // 
            // rb_putty
            // 
            this.rb_putty.AutoSize = true;
            this.rb_putty.Depth = 0;
            this.rb_putty.Location = new System.Drawing.Point(74, 96);
            this.rb_putty.Margin = new System.Windows.Forms.Padding(0);
            this.rb_putty.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rb_putty.MouseState = MaterialSkin.MouseState.HOVER;
            this.rb_putty.Name = "rb_putty";
            this.rb_putty.Ripple = true;
            this.rb_putty.Size = new System.Drawing.Size(118, 37);
            this.rb_putty.TabIndex = 2;
            this.rb_putty.TabStop = true;
            this.rb_putty.Text = "Putty (SSH)";
            this.rb_putty.UseVisualStyleBackColor = true;
            this.rb_putty.CheckedChanged += new System.EventHandler(this.rb_putty_CheckedChanged);
            // 
            // lbl_account
            // 
            this.lbl_account.AutoSize = true;
            this.lbl_account.Depth = 0;
            this.lbl_account.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_account.Location = new System.Drawing.Point(51, 14);
            this.lbl_account.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_account.Name = "lbl_account";
            this.lbl_account.Size = new System.Drawing.Size(63, 19);
            this.lbl_account.TabIndex = 1;
            this.lbl_account.Text = "Account:";
            // 
            // comb_accounts
            // 
            this.comb_accounts.AutoResize = false;
            this.comb_accounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comb_accounts.Depth = 0;
            this.comb_accounts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comb_accounts.DropDownHeight = 174;
            this.comb_accounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_accounts.DropDownWidth = 121;
            this.comb_accounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comb_accounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comb_accounts.FormattingEnabled = true;
            this.comb_accounts.IntegralHeight = false;
            this.comb_accounts.ItemHeight = 43;
            this.comb_accounts.Location = new System.Drawing.Point(54, 38);
            this.comb_accounts.MaxDropDownItems = 4;
            this.comb_accounts.MouseState = MaterialSkin.MouseState.OUT;
            this.comb_accounts.Name = "comb_accounts";
            this.comb_accounts.Size = new System.Drawing.Size(505, 49);
            this.comb_accounts.TabIndex = 0;
            this.comb_accounts.SelectedIndexChanged += new System.EventHandler(this.comb_accounts_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.materialLabel1);
            this.tabPage2.Controls.Add(this.btn_filezillaSearch);
            this.tabPage2.Controls.Add(this.btn_winscpSearch);
            this.tabPage2.Controls.Add(this.btn_puttySearch);
            this.tabPage2.Controls.Add(this.btn_heidiSearch);
            this.tabPage2.Controls.Add(this.btn_cfg_cancel);
            this.tabPage2.Controls.Add(this.btn_cfg_save);
            this.tabPage2.Controls.Add(this.btn_heidiInstall);
            this.tabPage2.Controls.Add(this.btn_puttyInstall);
            this.tabPage2.Controls.Add(this.btn_winscpInstall);
            this.tabPage2.Controls.Add(this.btn_filezillaInstall);
            this.tabPage2.Controls.Add(this.materialLabel5);
            this.tabPage2.Controls.Add(this.lbl_heidiPath);
            this.tabPage2.Controls.Add(this.lbl_puttyPath);
            this.tabPage2.Controls.Add(this.lbl_winscpPath);
            this.tabPage2.Controls.Add(this.lbl_filezillaPath);
            this.tabPage2.Controls.Add(this.txt_heidiPath);
            this.tabPage2.Controls.Add(this.txt_filesPass);
            this.tabPage2.Controls.Add(this.txt_winscpPath);
            this.tabPage2.Controls.Add(this.txt_puttyPath);
            this.tabPage2.Controls.Add(this.txt_filezillaPath);
            this.tabPage2.ImageKey = "settings.png";
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(797, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(131, 425);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(586, 41);
            this.materialLabel1.TabIndex = 20;
            this.materialLabel1.Text = "Please, write the password in somewhere. because if you lose it, you could lose a" +
    "ll your saved accounts";
            // 
            // btn_filezillaSearch
            // 
            this.btn_filezillaSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_filezillaSearch.Depth = 0;
            this.btn_filezillaSearch.DrawShadows = true;
            this.btn_filezillaSearch.HighEmphasis = true;
            this.btn_filezillaSearch.Icon = null;
            this.btn_filezillaSearch.Location = new System.Drawing.Point(599, 26);
            this.btn_filezillaSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_filezillaSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_filezillaSearch.Name = "btn_filezillaSearch";
            this.btn_filezillaSearch.Size = new System.Drawing.Size(33, 36);
            this.btn_filezillaSearch.TabIndex = 19;
            this.btn_filezillaSearch.Text = "...";
            this.btn_filezillaSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_filezillaSearch.UseAccentColor = false;
            this.btn_filezillaSearch.UseVisualStyleBackColor = true;
            this.btn_filezillaSearch.Click += new System.EventHandler(this.btn_filezillaSearch_Click);
            // 
            // btn_winscpSearch
            // 
            this.btn_winscpSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_winscpSearch.Depth = 0;
            this.btn_winscpSearch.DrawShadows = true;
            this.btn_winscpSearch.HighEmphasis = true;
            this.btn_winscpSearch.Icon = null;
            this.btn_winscpSearch.Location = new System.Drawing.Point(599, 103);
            this.btn_winscpSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_winscpSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_winscpSearch.Name = "btn_winscpSearch";
            this.btn_winscpSearch.Size = new System.Drawing.Size(33, 36);
            this.btn_winscpSearch.TabIndex = 18;
            this.btn_winscpSearch.Text = "...";
            this.btn_winscpSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_winscpSearch.UseAccentColor = false;
            this.btn_winscpSearch.UseVisualStyleBackColor = true;
            this.btn_winscpSearch.Click += new System.EventHandler(this.btn_winscpSearch_Click);
            // 
            // btn_puttySearch
            // 
            this.btn_puttySearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_puttySearch.Depth = 0;
            this.btn_puttySearch.DrawShadows = true;
            this.btn_puttySearch.HighEmphasis = true;
            this.btn_puttySearch.Icon = null;
            this.btn_puttySearch.Location = new System.Drawing.Point(599, 180);
            this.btn_puttySearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_puttySearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_puttySearch.Name = "btn_puttySearch";
            this.btn_puttySearch.Size = new System.Drawing.Size(33, 36);
            this.btn_puttySearch.TabIndex = 17;
            this.btn_puttySearch.Text = "...";
            this.btn_puttySearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_puttySearch.UseAccentColor = false;
            this.btn_puttySearch.UseVisualStyleBackColor = true;
            this.btn_puttySearch.Click += new System.EventHandler(this.btn_puttySearch_Click);
            // 
            // btn_heidiSearch
            // 
            this.btn_heidiSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_heidiSearch.Depth = 0;
            this.btn_heidiSearch.DrawShadows = true;
            this.btn_heidiSearch.HighEmphasis = true;
            this.btn_heidiSearch.Icon = null;
            this.btn_heidiSearch.Location = new System.Drawing.Point(599, 259);
            this.btn_heidiSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_heidiSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_heidiSearch.Name = "btn_heidiSearch";
            this.btn_heidiSearch.Size = new System.Drawing.Size(33, 36);
            this.btn_heidiSearch.TabIndex = 16;
            this.btn_heidiSearch.Text = "...";
            this.btn_heidiSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_heidiSearch.UseAccentColor = false;
            this.btn_heidiSearch.UseVisualStyleBackColor = true;
            this.btn_heidiSearch.Click += new System.EventHandler(this.btn_heidiSearch_Click);
            // 
            // btn_cfg_cancel
            // 
            this.btn_cfg_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cfg_cancel.Depth = 0;
            this.btn_cfg_cancel.DrawShadows = true;
            this.btn_cfg_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cfg_cancel.HighEmphasis = true;
            this.btn_cfg_cancel.Icon = null;
            this.btn_cfg_cancel.Location = new System.Drawing.Point(574, 487);
            this.btn_cfg_cancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_cfg_cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cfg_cancel.Name = "btn_cfg_cancel";
            this.btn_cfg_cancel.Size = new System.Drawing.Size(77, 36);
            this.btn_cfg_cancel.TabIndex = 15;
            this.btn_cfg_cancel.Text = "Cancel";
            this.btn_cfg_cancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_cfg_cancel.UseAccentColor = false;
            this.btn_cfg_cancel.UseVisualStyleBackColor = true;
            this.btn_cfg_cancel.Click += new System.EventHandler(this.btn_cfg_cancel_Click);
            // 
            // btn_cfg_save
            // 
            this.btn_cfg_save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cfg_save.Depth = 0;
            this.btn_cfg_save.DrawShadows = true;
            this.btn_cfg_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cfg_save.HighEmphasis = true;
            this.btn_cfg_save.Icon = null;
            this.btn_cfg_save.Location = new System.Drawing.Point(659, 487);
            this.btn_cfg_save.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_cfg_save.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cfg_save.Name = "btn_cfg_save";
            this.btn_cfg_save.Size = new System.Drawing.Size(58, 36);
            this.btn_cfg_save.TabIndex = 14;
            this.btn_cfg_save.Text = "SAVE";
            this.btn_cfg_save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_cfg_save.UseAccentColor = false;
            this.btn_cfg_save.UseVisualStyleBackColor = true;
            this.btn_cfg_save.Click += new System.EventHandler(this.btn_cfg_save_Click);
            // 
            // btn_heidiInstall
            // 
            this.btn_heidiInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_heidiInstall.Depth = 0;
            this.btn_heidiInstall.DrawShadows = true;
            this.btn_heidiInstall.HighEmphasis = true;
            this.btn_heidiInstall.Icon = null;
            this.btn_heidiInstall.Location = new System.Drawing.Point(640, 259);
            this.btn_heidiInstall.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_heidiInstall.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_heidiInstall.Name = "btn_heidiInstall";
            this.btn_heidiInstall.Size = new System.Drawing.Size(79, 36);
            this.btn_heidiInstall.TabIndex = 13;
            this.btn_heidiInstall.Text = "install";
            this.btn_heidiInstall.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_heidiInstall.UseAccentColor = false;
            this.btn_heidiInstall.UseVisualStyleBackColor = true;
            this.btn_heidiInstall.Click += new System.EventHandler(this.btn_heidiInstall_Click);
            // 
            // btn_puttyInstall
            // 
            this.btn_puttyInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_puttyInstall.Depth = 0;
            this.btn_puttyInstall.DrawShadows = true;
            this.btn_puttyInstall.HighEmphasis = true;
            this.btn_puttyInstall.Icon = null;
            this.btn_puttyInstall.Location = new System.Drawing.Point(640, 180);
            this.btn_puttyInstall.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_puttyInstall.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_puttyInstall.Name = "btn_puttyInstall";
            this.btn_puttyInstall.Size = new System.Drawing.Size(79, 36);
            this.btn_puttyInstall.TabIndex = 12;
            this.btn_puttyInstall.Text = "Install";
            this.btn_puttyInstall.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_puttyInstall.UseAccentColor = false;
            this.btn_puttyInstall.UseVisualStyleBackColor = true;
            this.btn_puttyInstall.Click += new System.EventHandler(this.btn_puttyInstall_Click);
            // 
            // btn_winscpInstall
            // 
            this.btn_winscpInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_winscpInstall.Depth = 0;
            this.btn_winscpInstall.DrawShadows = true;
            this.btn_winscpInstall.HighEmphasis = true;
            this.btn_winscpInstall.Icon = null;
            this.btn_winscpInstall.Location = new System.Drawing.Point(640, 103);
            this.btn_winscpInstall.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_winscpInstall.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_winscpInstall.Name = "btn_winscpInstall";
            this.btn_winscpInstall.Size = new System.Drawing.Size(79, 36);
            this.btn_winscpInstall.TabIndex = 11;
            this.btn_winscpInstall.Text = "Install";
            this.btn_winscpInstall.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_winscpInstall.UseAccentColor = false;
            this.btn_winscpInstall.UseVisualStyleBackColor = true;
            this.btn_winscpInstall.Click += new System.EventHandler(this.btn_winscpInstall_Click);
            // 
            // btn_filezillaInstall
            // 
            this.btn_filezillaInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_filezillaInstall.Depth = 0;
            this.btn_filezillaInstall.DrawShadows = true;
            this.btn_filezillaInstall.HighEmphasis = true;
            this.btn_filezillaInstall.Icon = null;
            this.btn_filezillaInstall.Location = new System.Drawing.Point(640, 26);
            this.btn_filezillaInstall.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_filezillaInstall.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_filezillaInstall.Name = "btn_filezillaInstall";
            this.btn_filezillaInstall.Size = new System.Drawing.Size(79, 36);
            this.btn_filezillaInstall.TabIndex = 10;
            this.btn_filezillaInstall.Text = "Install";
            this.btn_filezillaInstall.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btn_filezillaInstall.UseAccentColor = false;
            this.btn_filezillaInstall.UseVisualStyleBackColor = true;
            this.btn_filezillaInstall.Click += new System.EventHandler(this.btn_filezillaInstall_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(16, 367);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(108, 19);
            this.materialLabel5.TabIndex = 9;
            this.materialLabel5.Text = "Files Password";
            // 
            // lbl_heidiPath
            // 
            this.lbl_heidiPath.AutoSize = true;
            this.lbl_heidiPath.Depth = 0;
            this.lbl_heidiPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_heidiPath.Location = new System.Drawing.Point(16, 269);
            this.lbl_heidiPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_heidiPath.Name = "lbl_heidiPath";
            this.lbl_heidiPath.Size = new System.Drawing.Size(86, 19);
            this.lbl_heidiPath.TabIndex = 8;
            this.lbl_heidiPath.Text = "Heidi    Path";
            // 
            // lbl_puttyPath
            // 
            this.lbl_puttyPath.AutoSize = true;
            this.lbl_puttyPath.Depth = 0;
            this.lbl_puttyPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_puttyPath.Location = new System.Drawing.Point(16, 190);
            this.lbl_puttyPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_puttyPath.Name = "lbl_puttyPath";
            this.lbl_puttyPath.Size = new System.Drawing.Size(92, 19);
            this.lbl_puttyPath.TabIndex = 7;
            this.lbl_puttyPath.Text = "Putty L. Path";
            // 
            // lbl_winscpPath
            // 
            this.lbl_winscpPath.AutoSize = true;
            this.lbl_winscpPath.Depth = 0;
            this.lbl_winscpPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_winscpPath.Location = new System.Drawing.Point(16, 113);
            this.lbl_winscpPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_winscpPath.Name = "lbl_winscpPath";
            this.lbl_winscpPath.Size = new System.Drawing.Size(95, 19);
            this.lbl_winscpPath.TabIndex = 6;
            this.lbl_winscpPath.Text = "WinSCP Path";
            // 
            // lbl_filezillaPath
            // 
            this.lbl_filezillaPath.AutoSize = true;
            this.lbl_filezillaPath.Depth = 0;
            this.lbl_filezillaPath.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_filezillaPath.Location = new System.Drawing.Point(16, 36);
            this.lbl_filezillaPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_filezillaPath.Name = "lbl_filezillaPath";
            this.lbl_filezillaPath.Size = new System.Drawing.Size(92, 19);
            this.lbl_filezillaPath.TabIndex = 5;
            this.lbl_filezillaPath.Text = "Filezilla Path";
            // 
            // txt_heidiPath
            // 
            this.txt_heidiPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_heidiPath.Depth = 0;
            this.txt_heidiPath.Enabled = false;
            this.txt_heidiPath.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_heidiPath.Location = new System.Drawing.Point(134, 256);
            this.txt_heidiPath.MaxLength = 50;
            this.txt_heidiPath.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_heidiPath.Multiline = false;
            this.txt_heidiPath.Name = "txt_heidiPath";
            this.txt_heidiPath.Size = new System.Drawing.Size(458, 50);
            this.txt_heidiPath.TabIndex = 4;
            this.txt_heidiPath.Text = "";
            // 
            // txt_filesPass
            // 
            this.txt_filesPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_filesPass.Depth = 0;
            this.txt_filesPass.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_filesPass.Location = new System.Drawing.Point(134, 352);
            this.txt_filesPass.MaxLength = 50;
            this.txt_filesPass.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_filesPass.Multiline = false;
            this.txt_filesPass.Name = "txt_filesPass";
            this.txt_filesPass.Password = true;
            this.txt_filesPass.Size = new System.Drawing.Size(583, 50);
            this.txt_filesPass.TabIndex = 3;
            this.txt_filesPass.Text = "";
            // 
            // txt_winscpPath
            // 
            this.txt_winscpPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_winscpPath.Depth = 0;
            this.txt_winscpPath.Enabled = false;
            this.txt_winscpPath.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_winscpPath.Location = new System.Drawing.Point(134, 100);
            this.txt_winscpPath.MaxLength = 50;
            this.txt_winscpPath.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_winscpPath.Multiline = false;
            this.txt_winscpPath.Name = "txt_winscpPath";
            this.txt_winscpPath.Size = new System.Drawing.Size(458, 50);
            this.txt_winscpPath.TabIndex = 2;
            this.txt_winscpPath.Text = "";
            // 
            // txt_puttyPath
            // 
            this.txt_puttyPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_puttyPath.Depth = 0;
            this.txt_puttyPath.Enabled = false;
            this.txt_puttyPath.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_puttyPath.Location = new System.Drawing.Point(134, 177);
            this.txt_puttyPath.MaxLength = 50;
            this.txt_puttyPath.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_puttyPath.Multiline = false;
            this.txt_puttyPath.Name = "txt_puttyPath";
            this.txt_puttyPath.Size = new System.Drawing.Size(458, 50);
            this.txt_puttyPath.TabIndex = 1;
            this.txt_puttyPath.Text = "";
            // 
            // txt_filezillaPath
            // 
            this.txt_filezillaPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_filezillaPath.Depth = 0;
            this.txt_filezillaPath.Enabled = false;
            this.txt_filezillaPath.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_filezillaPath.Location = new System.Drawing.Point(134, 24);
            this.txt_filezillaPath.MaxLength = 50;
            this.txt_filezillaPath.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_filezillaPath.Multiline = false;
            this.txt_filezillaPath.Name = "txt_filezillaPath";
            this.txt_filezillaPath.Size = new System.Drawing.Size(458, 50);
            this.txt_filezillaPath.TabIndex = 0;
            this.txt_filezillaPath.Text = "";
            // 
            // img_list_icons
            // 
            this.img_list_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_list_icons.ImageStream")));
            this.img_list_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.img_list_icons.Images.SetKeyName(0, "dashboard.png");
            this.img_list_icons.Images.SetKeyName(1, "secure.png");
            this.img_list_icons.Images.SetKeyName(2, "settings.png");
            this.img_list_icons.Images.SetKeyName(3, "information.png");
            // 
            // ofd_searchApps
            // 
            this.ofd_searchApps.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 603);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utility Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.TextBoxContextMenuStrip textBoxContextMenuStrip1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ImageList img_list_icons;
        private MaterialSkin.Controls.MaterialComboBox comb_accounts;
        private MaterialSkin.Controls.MaterialButton btn_cfg_cancel;
        private MaterialSkin.Controls.MaterialButton btn_cfg_save;
        private MaterialSkin.Controls.MaterialButton btn_heidiInstall;
        private MaterialSkin.Controls.MaterialButton btn_puttyInstall;
        private MaterialSkin.Controls.MaterialButton btn_winscpInstall;
        private MaterialSkin.Controls.MaterialButton btn_filezillaInstall;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel lbl_heidiPath;
        private MaterialSkin.Controls.MaterialLabel lbl_puttyPath;
        private MaterialSkin.Controls.MaterialLabel lbl_winscpPath;
        private MaterialSkin.Controls.MaterialLabel lbl_filezillaPath;
        private MaterialSkin.Controls.MaterialTextBox txt_heidiPath;
        private MaterialSkin.Controls.MaterialTextBox txt_filesPass;
        private MaterialSkin.Controls.MaterialTextBox txt_winscpPath;
        private MaterialSkin.Controls.MaterialTextBox txt_puttyPath;
        private MaterialSkin.Controls.MaterialTextBox txt_filezillaPath;
        private MaterialSkin.Controls.MaterialButton btn_filezillaSearch;
        private MaterialSkin.Controls.MaterialButton btn_winscpSearch;
        private MaterialSkin.Controls.MaterialButton btn_puttySearch;
        private MaterialSkin.Controls.MaterialButton btn_heidiSearch;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel lbl_account;
        private MaterialSkin.Controls.MaterialButton btn_delete;
        private MaterialSkin.Controls.MaterialButton btn_edit;
        private MaterialSkin.Controls.MaterialButton btn_open;
        private MaterialSkin.Controls.MaterialRadioButton rb_heidi;
        private MaterialSkin.Controls.MaterialRadioButton rb_filezilla;
        private MaterialSkin.Controls.MaterialRadioButton rb_winscp;
        private MaterialSkin.Controls.MaterialRadioButton rb_putty;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialButton btn_clear;
        private MaterialSkin.Controls.MaterialButton btn_add_update;
        private MaterialSkin.Controls.MaterialTextBox txt_pass;
        private MaterialSkin.Controls.MaterialTextBox txt_user;
        private MaterialSkin.Controls.MaterialTextBox txt_name;
        private MaterialSkin.Controls.MaterialCheckbox chk_mysql;
        private MaterialSkin.Controls.MaterialCheckbox chk_sftp;
        private MaterialSkin.Controls.MaterialCheckbox chk_ftp;
        private MaterialSkin.Controls.MaterialCheckbox chk_ssh;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.OpenFileDialog ofd_searchApps;
        private MaterialSkin.Controls.MaterialButton btn_swithPass;
        private MaterialSkin.Controls.MaterialTextBox txt_host;
        private MaterialSkin.Controls.MaterialTextBox txt_port;
    }
}