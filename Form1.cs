using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using IWshRuntimeLibrary;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

// Started : 22.12.20

// Laisser le choix de l'ouverture automatique
// Avec un while file not exist, bloquer le décochage et idem si il exist

namespace Hours
{
    public partial class HoursForm : Form
    {
        public HoursForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static string TotalSecondes;
        public static string TotalMinutes;
        public static string TotalHeures;
        public static string TotalJours;
        public static string FirstLauch;
        public static string NowDate;
        public static Counter x;
        public static bool AlreadyMinimizeChecked = false;
        public static short ToCheckCounter = 0;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Permet de move en cliquant sur le panel gris du form
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private Timer timer1;

        // Timer qui execute la fonction Timer1_Tick à chaque timer1.Interval (1sec)
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void HoursForm_Load(object sender, EventArgs e)
        {
            // Lors du démarage, on lance le timer
            InitTimer();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            MainHours();
        }

        // Bouton pour minimiser
        private void MinimizeButton_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }

        // Bouton pour fermer Hours
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult CloseMSgBox = MessageBox.Show("Souhaitez-vous vraiment fermer Hours ?\nLe temps ne sera alors plus compté.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (CloseMSgBox == DialogResult.Yes) Close();
        }

        public class Counter
        {
            public long Time { get; set; }
            public string Date { get; set; }
            public string NowDate { get; set; }
            public bool StartWithWindows { get; set; }
            public bool RoundValues { get; set; }
        }

        private void MainHours()
        {
            // Check si le processus Hours est déjà en cours d'éxecution,
            // pour chaque processus, si l'id du processus est différent du current
            // Fermer le processus qui est actuel (ce qui signifie qu'il y en a eu un nouveau d'ouvert
            // Alors le laisser "prendre le dessus"

            Process[] HoursProc = Process.GetProcessesByName("Hours");
            foreach (Process phours in HoursProc)
            {
                // Si ouverture auto true, alors vérifier ça, sinon ne pas effectuer la Hide si rien n'est démarré avant
                if (phours.Id != Process.GetCurrentProcess().Id)
                    Close();
            }

            DateTime now = DateTime.Now;
            string DateNow = now.ToLocalTime().ToString();
            string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours\data.json";
            string HoursPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours";

            if (!System.IO.File.Exists(DataPath))
            {
                timer1.Stop();
                MessageBox.Show("Première ouverture d'Hours ?\nA chaque démarrage, il s'allumera tout seul", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Counter time = new Counter
                {
                    Time = 1,
                    Date = DateNow,
                    NowDate = DateNow,
                    StartWithWindows = false,
                    RoundValues = false,
                };

                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours");
                System.IO.File.WriteAllText(DataPath, JsonConvert.SerializeObject(time));

                using (StreamWriter file = System.IO.File.CreateText(DataPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, time);
                }
                timer1.Start();
                return;
            }

            string json = System.IO.File.ReadAllText($@"{DataPath}");
            Counter x;

            try
            {
                // Récup les données json de data.json
                x = JsonConvert.DeserializeObject<Counter>(json);
                // Vérifie si c'est bien en json
                var obj = JToken.Parse(json);
            }
            catch
            {
                /* Si les données dans data.json ne sont pas bonnes (pas json ou erreur dedans)
                 * Alors on stop le timer (évite la boucle chaque seconde...)
                 * Informe l'utilisateur
                 * Demande si l'utilisateur souhaite appliqué une backup et si oui,
                 * (1er try) on essaie de récupérer les informations dans data-backup.json comme pour le data.json
                 * Supprime data.json et le recréé avec les infos de data-backup
                 * Informe l'utilisateur que la backup à été appliqué,
                 * si jamais data-backup n'est pas bon également, alors :
                 * (2e try dans le catch) on essaie de récup les infos dans data-backup-old
                 * et comme pour data-backup on supprime etc on remplace...
                 * et si vraiment aucunes backups n'est valides, alors on supprime data.json et
                 * les données de l'utilisateur reprennent alors à 0 !
                 * On relance le timer ;)
                 *
                 * Si jamais l'utilisateur ne veut pas mettre de backup, on femre Hours :(
                */
                timer1.Stop();
                LabelTotalTime.Text = "Les données sont erronées...";
                DialogResult CantJson = MessageBox.Show($"La fichier de data est érroné, souhaitez-vous appliquer une backup ?", "Erreur :(", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (CantJson == DialogResult.Yes)
                {
                    try
                    {
                        string jsonbu = System.IO.File.ReadAllText($@"{HoursPath}\backups\data-backup.json");
                        var obj = JToken.Parse(jsonbu);
                        System.IO.File.Delete($@"{HoursPath}\data.json");
                        System.IO.File.Move($@"{HoursPath}\backups\data-backup.json", $@"{HoursPath}\data.json");
                        MessageBox.Show($"Une backup à été appliqué ! (data-backup)", "Réglé !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        try
                        {
                            string jsonbu_old = System.IO.File.ReadAllText($@"{HoursPath}\backups\data-backup-old.json");
                            var obj = JToken.Parse(jsonbu_old);
                            System.IO.File.Delete($@"{HoursPath}\data.json");
                            System.IO.File.Move($@"{HoursPath}\backups\data-backup-old.json", $@"{HoursPath}\data.json");
                            MessageBox.Show($"Une backup à été appliqué ! (data-backup-old)", "Réglé !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show($"Aucune backup correcte n'a été trouvé, une nouvelle session sera donc débuté (vous reprendrez donc à 0sec).\nN'hésitez pas à me contacter.", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            System.IO.File.Delete($@"{HoursPath}\data.json");
                        }
                    }
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show($"Hours va donc se fermer", "Fermeture due au fichié érroné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                return;
            }

            string ShortCutPrograms = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

            if (!System.IO.File.Exists($@"{ShortCutPrograms}\Hours.lnk"))
            {
                WshShellClass wsh = new WshShellClass();
                IWshShortcut shortcut = wsh.CreateShortcut($@"{ShortCutPrograms}\Hours.lnk") as IWshShortcut;
                shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = ShortCutPrograms;
                shortcut.Save();
            }

            if (ToCheckCounter == 0)
            {
                if (x.StartWithWindows == true)
                    CheckBoxStartMinimized.Checked = true;
                else
                    CheckBoxStartMinimized.Checked = false;

                if (x.RoundValues)
                    CheckboxArrondir.Checked = true;
                else
                    CheckboxArrondir.Checked = false;

                ToCheckCounter += 10;
            }
            else
                ToCheckCounter--;

            /* Check si le temps n'est pas trop abusé si oui on ajoute rien et on dit que le temps à été modifié
             * si non ajoute une seconde & la date
             * Effectue une backup
             */

            if (x.Time <= 9223372036854775806)
            {
                Counter timeAdder = new Counter
                {
                    Time = x.Time + 1,
                    Date = x.Date,
                    NowDate = DateNow,
                    StartWithWindows = x.StartWithWindows,
                    RoundValues = x.RoundValues,
                };

                System.IO.File.WriteAllText(DataPath, JsonConvert.SerializeObject(timeAdder));
                using (StreamWriter file = System.IO.File.CreateText(DataPath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, timeAdder);
                }

                BackUpFile();
            }
            else
            {
                LabelTotalTime.Text = $"Vous n'êtes pas humain, vous avez\nmodifié votre temps...";
                return;
            }

            double minutes = (double)x.Time / 60;
            double hours = minutes / 60;
            double days = hours / 24;

            if (CheckboxArrondir.Checked == false)
            {
                // Si l'utilisateur n'a pas coché pour arrondir, on arrondit pas :)
                LabelSeconds.Text = $"{x.Time} secondes";
                LabelMinutes.Text = $"{Math.Round((double)minutes, 2)} minutes";
                LabelHours.Text = $"{Math.Round((double)hours, 3)} heures";
                LabelDays.Text = $"{Math.Round((double)days, 3)} jours";
                LabelTotalTime.Text = $"Vous avez passé {Math.Round((double)hours, 5)} heures \navec votre pc d'allumé.";
                LabelFirstOpeningDate.Text = $"{x.Date}";
                LabelDateNow.Text = $"{x.NowDate}";
            }
            else
            {
                // Si l'utilisateur a coché pour arrondir, on arrondit :)
                LabelSeconds.Text = $"{x.Time} secondes";
                LabelMinutes.Text = $"{Math.Round((double)minutes, 0)} minutes";
                LabelHours.Text = $"{Math.Round((double)hours, 0)} heures";
                LabelDays.Text = $"{Math.Round((double)days, 0)} jours";
                LabelTotalTime.Text = $"Vous avez passé {Math.Round((double)hours, 0)} heures \navec votre pc d'allumé.";
                LabelFirstOpeningDate.Text = $"{x.Date}";
                LabelDateNow.Text = $"{x.NowDate}";
            }
            // ici je définis les variables qui seront utilisées si l'utilisateur partage.
            TotalSecondes = x.Time.ToString();
            TotalMinutes = Math.Round((double)minutes, 0).ToString();
            TotalHeures = Math.Round((double)hours, 0).ToString();
            TotalJours = Math.Round((double)days, 0).ToString();
            FirstLauch = x.Date;
            NowDate = x.NowDate;
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            // Si le bouton pour mettre en arrière plan
            DialogResult CloseMSgBox = MessageBox.Show("Souhaitez-vous vraiment mettre en arrière plan Hours ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (CloseMSgBox == DialogResult.Yes) Hide();
        }

        private void ButtonShare_Click(object sender, EventArgs e)
        {
            // Bouton partager cliqué : message copié dans le presse-papier
            Clipboard.SetText($"⏲ === Hours Score === ⏲\nDepuis que j'ai lancé Hours le {FirstLauch} et la date à laquelle j'ai enregistré mon score le {NowDate}, j'ai passé ~{TotalHeures} heures sur mon pc soit :\n     {TotalSecondes} secondes\n     ~{TotalMinutes} minutes\n     ~{TotalJours} jours\nTélécharge toi aussi Hours ici : https://github.com/Cu-chi !");
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            /* Boutton pour reset ses stats
             * Demande de confirmer et si oui on reset les dates
             * On fait une save
             * Et on delete data.json
            */
            DialogResult ResetMsgBox = MessageBox.Show($"Vous êtes sur le point de réinitialiser le temps enregistré.\nConfirmez-vous ?\n\nA noter qu'une sauvegarde sera effectuée, vous pourrez la trouver ici :\n{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Hours\\save\\", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ResetMsgBox == DialogResult.Yes)
            {
                DateTime now = DateTime.Now;
                string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours";
                string DateNow = now.ToLocalTime().ToString();
                if (!Directory.Exists(DataPath + @"\save")) Directory.CreateDirectory(DataPath + @"\save");
                if (!System.IO.File.Exists(DataPath + $@"\save\data-save-{DateNow.Replace(":", ".")}.json")) System.IO.File.Copy(DataPath + @"\data.json", DataPath + $@"\save\data-save-{DateNow.Replace(":", ".")}.json");
                else
                {
                    bool AlreadyExist = true;
                    sbyte i = 0;
                    string filename = $"data-save-{DateNow.Replace(":", ".")}";
                    string filepath = "";
                    while (AlreadyExist)
                    {
                        i += 1;
                        filepath = $@"{DataPath}\save\{filename}-{i}.json";
                        if (!System.IO.File.Exists(filepath))
                        {
                            AlreadyExist = false;
                        }
                    }
                    System.IO.File.Copy(DataPath + @"\data.json", filepath);
                }
                System.IO.File.Delete(DataPath + @"\data.json");
            }
        }

        private void BackUpFile()
        {
            /* Fonction de backup, a chaque seconde, on check si
             * backups existe, si non on le créé
             * si le fichier data-backup-old existe, on le delete
             * si le fichier data-back existe, on le copie en data-backup-old
             * pour finir on copie data en data-backup
            */
            string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours";
            if (!Directory.Exists($@"{DataPath}\backups")) Directory.CreateDirectory($@"{DataPath}\backups");

            if (System.IO.File.Exists($@"{DataPath}\backups\data-backup-old.json"))
                System.IO.File.Delete($@"{DataPath}\backups\data-backup-old.json");

            if (System.IO.File.Exists($@"{DataPath}\backups\data-backup.json"))
                System.IO.File.Move($@"{DataPath}\backups\data-backup.json", $@"{DataPath}\backups\data-backup-old.json");

            System.IO.File.Copy($@"{DataPath}\data.json", $@"{DataPath}\backups\data-backup.json");
        }

        private void ButtonStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Counter timeAdder;
            string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours\data.json";
            string json = System.IO.File.ReadAllText(DataPath);
            Counter x = JsonConvert.DeserializeObject<Counter>(json);
            string ShortCutBoot = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            if (CheckBoxStartMinimized.Checked == true)
            {
                if (!System.IO.File.Exists($@"{ShortCutBoot}\Hours.lnk"))
                {
                    WshShellClass wsh = new WshShellClass();
                    IWshShortcut shortcut = wsh.CreateShortcut($@"{ShortCutBoot}\Hours.lnk") as IWshShortcut;
                    shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    shortcut.WindowStyle = 1;
                    shortcut.WorkingDirectory = ShortCutBoot;
                    shortcut.Save();
                }

                timeAdder = new Counter
                {
                    Time = x.Time,
                    Date = x.Date,
                    NowDate = x.NowDate,
                    StartWithWindows = true,
                    RoundValues = x.RoundValues,
                };
            }
            else
            {
                System.IO.File.Delete($@"{ShortCutBoot}\Hours.lnk");
                timeAdder = new Counter
                {
                    Time = x.Time,
                    Date = x.Date,
                    NowDate = x.NowDate,
                    StartWithWindows = false,
                    RoundValues = x.RoundValues,
                };
            }

            System.IO.File.WriteAllText(DataPath, JsonConvert.SerializeObject(timeAdder));
            using (StreamWriter file = System.IO.File.CreateText(DataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, timeAdder);
            }
        }

        private void CheckboxArrondir_CheckedChanged(object sender, EventArgs e)
        {
            Counter timeAdder;
            string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Hours\data.json";
            string json = System.IO.File.ReadAllText(DataPath);
            Counter x = JsonConvert.DeserializeObject<Counter>(json);
            if (CheckboxArrondir.Checked == true)
            {
                timeAdder = new Counter
                {
                    Time = x.Time,
                    Date = x.Date,
                    NowDate = x.NowDate,
                    StartWithWindows = x.StartWithWindows,
                    RoundValues = true,
                };
            }
            else
            {
                timeAdder = new Counter
                {
                    Time = x.Time,
                    Date = x.Date,
                    NowDate = x.NowDate,
                    StartWithWindows = x.StartWithWindows,
                    RoundValues = false,
                };
            }

            System.IO.File.WriteAllText(DataPath, JsonConvert.SerializeObject(timeAdder));
            using (StreamWriter file = System.IO.File.CreateText(DataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, timeAdder);
            }
        }
    }
}