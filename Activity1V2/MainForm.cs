using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Activity1V2
{
    public partial class MainForm : Form
    {
        private MySqlConnection conn;

        //LoginPanel essentials
        private System.Windows.Forms.Timer loginBtnTimer;
        TableForms tableforms = new TableForms();
        WelcomeForms welcomeForms = new WelcomeForms();
        private string adminUsername = "Admin";
        private string adminPassword = "admin123";
        public int loginAttempts = 0;
        public int currentAttempts = 3;
        private bool cooldownActive = false;

        //CreatePanel essentials
        private string[] genders = { "Male", "Female" };

        //ForgotPassPanel essentials
        private bool isPanel1Visible = true;
        private int animationDistance = 10;
        private Timer timer1;
        private Point passwordRecoPanelOriginalLocation;
        private Point resetPassPanelOriginalLocation;

        public MainForm()
        {
            InitializeComponent();

            string mysqlcon = "server=localhost;user=root;database=moonbasedatabase;password=";
            conn = new MySqlConnection(mysqlcon);

            //To show the LoginPanel as the starting panel
            LoginPanel.Show();
            ForgotPassPanel.Hide();
            CreateAccPanel.Hide();

            //LoginPanel essentials
            loginBtnTimer = new System.Windows.Forms.Timer();
            loginBtnTimer.Interval = 10000;
            loginBtnTimer.Tick += LoginBtnTimer_Tick;

            //CreatePanel essentials
            GenderComBox.Items.AddRange(genders);
            GenderComBox.DropDownStyle = ComboBoxStyle.DropDownList;

            NameLbl.Parent = CreatePanelPic;
            AgeLbl.Parent = CreatePanelPic;
            GenderLbl.Parent = CreatePanelPic;
            UsernameLblCP.Parent = CreatePanelPic;
            PasswordLblCP.Parent = CreatePanelPic;
            EmailLblCP.Parent = CreatePanelPic;
            ShowChckBoxCP.Parent = CreatePanelPic;
            CreateAccBtn.Parent = CreatePanelPic;

            //ForgotPassPanel essentials
            timer1 = new Timer();
            timer1.Interval = 10; // ito yung bilis ng travel, the higher the smoother
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        //LoginPanel elements and methods only
        private void CreateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccPanel.Show();
            ForgotPassPanel.Hide();
            LoginPanel.Hide();
        }

        private void ForgotPassLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassPanel.Show();
            LoginPanel.Hide();
            CreateAccPanel.Hide();
        }

        private void LoginBtn_Click(object sender, System.EventArgs e)
        {
            string usernameInput = UsernameComBox.Text;
            string enteredPassword = PasswordTxtBox.Text;
            string passwordInput = PasswordEncrypter.hashPassword(PasswordTxtBox.Text);
            bool accountActive = false;

            string selectQuery = $"SELECT HashedPassword, Status FROM mbuserinfo WHERE Username = '{usernameInput}'";
            MySqlCommand cmdDataBase = new MySqlCommand(selectQuery, conn);
            MySqlDataReader myReader;

            if (string.IsNullOrWhiteSpace(usernameInput) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please fill in all required fields.", " Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RememberChkBox.CheckState = CheckState.Unchecked;
                ErrorAttempts();
                return;
            }

            if (usernameInput == adminUsername)
            {
                if (enteredPassword == adminPassword)
                {
                    loginAttempts = 0;
                    currentAttempts = 3;

                    MessageBox.Show("Hi Admin, Welcome!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WindowState = FormWindowState.Minimized;
                    tableforms.ShowDialog();
                    this.WindowState = FormWindowState.Normal;
                    RememberAccount();

                    UsernameComBox.ResetText();
                    PasswordTxtBox.Clear();
                    RememberChkBox.CheckState = CheckState.Unchecked;

                    return;
                }
                else
                {
                    MessageBox.Show("Invalid admin password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PasswordTxtBox.Clear();
                    return;
                }
            }

            try
            {
                try
                {

                    conn.Open();
                    string selectPassword = $"SELECT Username FROM mbuserinfo WHERE HashedPassword = '{passwordInput}'";
                    MySqlCommand cmdDataBase1 = new MySqlCommand(selectPassword, conn);
                    MySqlDataReader myReader1;
                    myReader1 = cmdDataBase1.ExecuteReader();
                    if (myReader1.Read())
                    {
                        string databaseUsername = myReader1["Username"].ToString();

                        if (databaseUsername != usernameInput)
                        {
                            MessageBox.Show($"Invalid Username", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            UsernameComBox.ResetText();
                            //PasswordTxtBox.Clear();
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }

                conn.Open();
                myReader = cmdDataBase.ExecuteReader();
                if (myReader.Read())
                {
                    string databasePassword = myReader["HashedPassword"].ToString();
                    string accountStatus = myReader["Status"].ToString();

                    if (accountStatus == "ACTIVATED")
                    {
                        accountActive = true;
                    }

                    if (!accountActive)
                    {
                        MessageBox.Show("Wait for the admin to approve your account", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UsernameComBox.ResetText();
                        PasswordTxtBox.Clear();
                        RememberChkBox.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        if (passwordInput != databasePassword)
                        {
                            MessageBox.Show($"Invalid Password", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            PasswordTxtBox.Clear();
                            ErrorAttempts();
                        }
                        else
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RememberAccount();
                            this.WindowState = FormWindowState.Minimized;
                            welcomeForms.ShowDialog();
                            this.WindowState = FormWindowState.Normal;
                            loginAttempts = 0;
                            UsernameComBox.ResetText();
                            PasswordTxtBox.Clear();

                            currentAttempts = 3;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Invalid Credentials", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsernameComBox.ResetText();
                    PasswordTxtBox.Clear();
                    ErrorAttempts();

                }
            }

            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        public void ErrorAttempts()
        {
            if (currentAttempts > 0)
            {
                currentAttempts--;
                MessageBox.Show($"{currentAttempts} {(currentAttempts > 1 ? "attempts" : "attempts")} remaining", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            loginAttempts++;

            if (loginAttempts == 3)
            {
                LoginBtn.Enabled = false;
                StartTimer();
            }

            if (currentAttempts <= 0)
            {
                currentAttempts = 3;
            }
        }
        public void StartTimer()
        {
            cooldownActive = true;
            loginBtnTimer.Start();

        }
        private void LoginBtnTimer_Tick(object sender, EventArgs e)
        {
            cooldownActive = false;
            loginBtnTimer.Stop();
            LoginBtn.Enabled = true;
            loginAttempts = 0;
            MessageBox.Show("Cooldown period ended. You can try again now.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (ShowBtn.Visible == true) // Check if showBtn is visible
            {
                ShowBtn.Visible = false;
                CloseBtn.Visible = true;
                PasswordTxtBox.PasswordChar = '*'; // Hide password
            }
        }
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (CloseBtn.Visible == true) // Check if closeBtn is visible
            {
                ShowBtn.Visible = true;
                CloseBtn.Visible = false;
                PasswordTxtBox.PasswordChar = '\0'; // Show password
            }
        }


        private void RememberAccount()
        {
            string newItem = UsernameComBox.Text.Trim();
            bool itemExists = UsernameComBox.Items.Contains(newItem);
            if (RememberChkBox.Checked == true && !itemExists)
            {
                UsernameComBox.Items.Add(newItem);
                UsernameComBox.SelectedIndex = UsernameComBox.Items.IndexOf(newItem);
                UsernameComBox.Text = "";
            }
        }

        //CreatePanel elements and methods only
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
            ForgotPassPanel.Hide();
            CreateAccPanel.Hide();
        }
        private void GenderComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenderComBox.SelectedItem != null)
            {
                GenderComBox.Text = GenderComBox.SelectedItem.ToString();
            }
        }
        private void ShowChckBoxCP_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowChckBoxCP.Checked)
            {
                PasswordTxtBoxCP.PasswordChar = '\0';
            }
            else
            {
                PasswordTxtBoxCP.PasswordChar = '*';
            }
        }

        private void NameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    throw new Exception("Inputted character is not allowed");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgeTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    throw new Exception("Inputted character is not allowed");
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            string adminUsername = "Admin";
            string fixedSalt = "xCv12dFqwS";
            string randomSalt = PasswordEncrypter.generateSalt();
            string addEmail = "@gmail.com";


            if (string.IsNullOrWhiteSpace(NameTxtBox.Text) || string.IsNullOrWhiteSpace(AgeTxtBox.Text) || string.IsNullOrWhiteSpace(UsernameTxtBoxCP.Text)
                || string.IsNullOrWhiteSpace(PasswordTxtBoxCP.Text) || string.IsNullOrWhiteSpace(EmailTxtBoxCP.Text) || GenderComBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all the required data", "Missing Informations", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (UsernameTxtBoxCP.Text == adminUsername)
            {
                MessageBox.Show("The entered username is not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult choices = MessageBox.Show("Are you sure to the information that you have entered?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choices == DialogResult.Yes)
            {
                string insertQuery = "INSERT INTO mbuserinfo (FullName, Age, Gender, Username, Email, HashedPassword, FixedSaltedPassword, RandomString, RandomSaltedPassword) " +
                    "values('" + this.NameTxtBox.Text + "', '" + this.AgeTxtBox.Text + "', '" + this.GenderComBox.SelectedItem.ToString() + "', '" + this.UsernameTxtBoxCP.Text + "', '" + this.EmailTxtBoxCP.Text + addEmail + "', '" + PasswordEncrypter.hashPassword(PasswordTxtBoxCP.Text) + "', " +
                    "'" + PasswordEncrypter.fixedSaltPassword(PasswordTxtBoxCP.Text, fixedSalt) + "', '" + randomSalt + "','" + PasswordEncrypter.randomSaltPassword(PasswordTxtBoxCP.Text, randomSalt) + "')";
                MySqlCommand cmdDataBase = new MySqlCommand(insertQuery, conn);

                try
                {
                    conn.Open();
                    cmdDataBase.ExecuteNonQuery();
                    MessageBox.Show("Account Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    NameTxtBox.Clear();
                    AgeTxtBox.Clear();
                    UsernameTxtBoxCP.Clear();
                    PasswordTxtBoxCP.Clear();
                    EmailTxtBoxCP.Clear();
                    GenderComBox.SelectedItem = null;
                }

                catch (MySqlException a)
                {
                    if (a.Number == 1062)
                    {
                        MessageBox.Show("Username already exists.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UsernameTxtBoxCP.Clear();
                    }
                    else
                    {
                        MessageBox.Show(a.Message, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }

                finally
                {
                    conn.Close();
                }
            }
        }

        //ForgotPassPanel elements and methods
        private void BackBtn_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
            ForgotPassPanel.Hide();
            CreateAccPanel.Hide();
            UsernameTxtBoxPR.Clear();
            EmailTxtBoxPR.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ResetPanel.Visible = false;
            passwordRecoPanelOriginalLocation = RecoveryPanel.Location;
            resetPassPanelOriginalLocation = ResetPanel.Location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // adjust ang margin to get the desired location
            int margin = 100;

            // Horizontal ang magiging travel nito 
            if (RecoveryPanel.Left > margin && ResetPanel.Right < this.ClientSize.Width - margin)
            {
                // Movement ng panel form left and right
                RecoveryPanel.Left -= animationDistance;
                ResetPanel.Left += animationDistance;
            }
            else
            {
                //Stop yung timer and travel
                timer1.Stop();
            }
        }

        private void VerifyBtn_Click(object sender, EventArgs e)
        {
            string enteredUsername = UsernameTxtBoxPR.Text;
            string enteredEmail = EmailLblPR.Text;

            if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredEmail))
            {
                MessageBox.Show("Please fill in all required fields.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (conn)
                {
                    try
                    {
                        conn.Open();
                        string checkUserEmailQuery = "SELECT Email FROM mbuserinfo WHERE Username = @Username AND Status = 'ACTIVATED'";
                        using (MySqlCommand checkUserEmailCommand = new MySqlCommand(checkUserEmailQuery, conn))
                        {
                            checkUserEmailCommand.Parameters.AddWithValue("@Username", enteredUsername);

                            object result = checkUserEmailCommand.ExecuteScalar();

                            if (result != null)
                            {
                                MessageBox.Show("You can now proceed with resetting your password.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                /*UsernameTxtBoxPR.Clear();
                                EmailTxtBoxPR.Clear();*/

                                timer1.Start();
                                ResetPanel.Visible = true;

                                UsernameTxtBoxPR.Enabled = false;
                                EmailTxtBoxPR.Enabled = false;
                                VerifyBtn.Enabled = false;
                                BackBtnPR.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Username and/or email not found.", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                UsernameTxtBoxPR.Clear();
                                EmailTxtBoxPR.Clear();
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void BackBtnRP_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
            ForgotPassPanel.Hide();
            CreateAccPanel.Hide();
            TextBoxCleaner();

            RecoveryPanel.Location = passwordRecoPanelOriginalLocation;
            ResetPanel.Location = resetPassPanelOriginalLocation;
            ResetPanel.Visible = false;
        }

        private void UpdateBtnRP_Click(object sender, EventArgs e)
        {
            string enteredNewPassword = NewPassTxtBoxRP.Text;
            string newConfirmedPassword = ConPassTxtBoxRP.Text;
            string fixedSalt = "xCv12dFqwS";
            string randomSalt = PasswordEncrypter.generateSalt();

            if (string.IsNullOrWhiteSpace(enteredNewPassword) || string.IsNullOrWhiteSpace(newConfirmedPassword))
            {
                MessageBox.Show("Please fill in all required fields.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (enteredNewPassword != newConfirmedPassword)
            {
                MessageBox.Show("Passwords do not match.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string enteredUsername = UsernameTxtBoxPR.Text;
                string enteredEmail = EmailTxtBoxPR.Text;
                string newPassword = NewPassTxtBoxRP.Text;

                string connectionString = "server=localhost;user=root;database=moonbasedatabase;password=";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updatePasswordQuery = "UPDATE mbuserinfo SET HashedPassword = @HashedPassword, FixedSaltedPassword = @FixedSaltedPassword, RandomString = @RandomString, RandomSaltedPassword = @RandomSaltedPassword WHERE Username = @Username AND Email = @Email";

                        MySqlCommand cmd = new MySqlCommand(updatePasswordQuery, connection);
                        string hashedNewPassword = PasswordEncrypter.hashPassword(newPassword);
                        cmd.Parameters.AddWithValue("@HashedPassword", hashedNewPassword);

                        string fixedSaltedPassword = PasswordEncrypter.fixedSaltPassword(newPassword, fixedSalt);
                        cmd.Parameters.AddWithValue("@FixedSaltedPassword", fixedSaltedPassword);


                        string randomAsin = randomSalt;
                        cmd.Parameters.AddWithValue("@RandomString", randomAsin);

                        string randomSaltedPassword = PasswordEncrypter.randomSaltPassword(newPassword, randomSalt);
                        cmd.Parameters.AddWithValue("@RandomSaltedPassword", randomSaltedPassword);

                        cmd.Parameters.AddWithValue("@Username", enteredUsername);
                        cmd.Parameters.AddWithValue("@Email", enteredEmail);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DialogResult confirmationResult = MessageBox.Show("Your password has been successfully reset.", "PASSWORD RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoginPanel.Show();
                            ForgotPassPanel.Hide();
                            CreateAccPanel.Hide();
                            TextBoxCleaner();

                            RecoveryPanel.Location = passwordRecoPanelOriginalLocation;
                            ResetPanel.Location = resetPassPanelOriginalLocation;
                            ResetPanel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Password reset failed.", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NewPassTxtBoxRP.Clear();
                            ConPassTxtBoxRP.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void TextBoxCleaner()
        {
            UsernameTxtBoxPR.Clear();
            EmailTxtBoxPR.Clear();
            NewPassTxtBoxRP.Clear();
            ConPassTxtBoxRP.Clear();
            UsernameTxtBoxPR.Enabled = true;
            EmailTxtBoxPR.Enabled = true;
            VerifyBtn.Enabled = true;
            BackBtnPR.Enabled = true;
        }

        private void OpenBtnPR1_Click(object sender, EventArgs e)
        {
            if (OpenBtnPR1.Visible == true) // Check if showBtn is visible
            {
                OpenBtnPR1.Visible = false;
                CloseBtnPR1.Visible = true;
                NewPassTxtBoxRP.PasswordChar = '*'; // Hide password
            }
        }

        private void CloseBtnPR1_Click(object sender, EventArgs e)
        {
            if (CloseBtnPR1.Visible == true) // Check if closeBtn is visible
            {
                OpenBtnPR1.Visible = true;
                CloseBtnPR1.Visible = false;
                NewPassTxtBoxRP.PasswordChar = '\0'; // Show password
            }
        }

        private void OpenBtnPR2_Click(object sender, EventArgs e)
        {
            if (OpenBtnPR2.Visible == true) // Check if showBtn is visible
            {
                OpenBtnPR2.Visible = false;
                CloseBtnPR2.Visible = true;
                ConPassTxtBoxRP.PasswordChar = '*'; // Hide password
            }
        }

        private void CloseBtnPR2_Click(object sender, EventArgs e)
        {
            if (CloseBtnPR2.Visible == true) // Check if closeBtn is visible
            {
                OpenBtnPR2.Visible = true;
                CloseBtnPR2.Visible = false;
                ConPassTxtBoxRP.PasswordChar = '\0'; // Show password
            }
        }
    }
}

