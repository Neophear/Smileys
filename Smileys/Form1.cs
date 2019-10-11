using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Smileys
{
    public partial class MainForm : Form
    {
        Settings setting;
        List<SizeSetting> sizes = SizeSetting.Sizes();
        string applicationPath;
        string settingspath;
        public Timer bottomLabelTimer { get; set; }
        public string defaultBottomMsg = "Click on a smiley to Copy it to clipboard - Made by Stiig Gade";
        public string love = String.Empty;

        public MainForm()
        {
            InitializeComponent();

            bottomLabelTimer = new Timer();
            bottomLabelTimer.Interval = 4000;
            bottomLabelTimer.Tick += bottomLabelTimer_Tick;
            tssBottom.Text = defaultBottomMsg;
            applicationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Smileys\\";
            settingspath = applicationPath + "settings.xml";
            Directory.CreateDirectory(applicationPath);

            try
            {
                setting = Settings.Deserialize(settingspath);
            }
            catch (FileNotFoundException)
            {
                setting = new Settings();
            }
            catch (InvalidOperationException)
            {
                setting = new Settings();
            }

            if (setting.windowsSize != Size.Empty)
                this.Size = setting.windowsSize;

            cbAllwaysOnTop.Checked = this.TopMost = setting.alwaysOnTop;
            cbSize.DataSource = SizeSetting.Sizes();
            cbSize.SelectedIndex = sizes.FindIndex(x => x.intSize == setting.size);

            foreach (Smiley s in Smiley.AllSmileys())
            {
                Button b = new Button();
                b.BackgroundImage = s.Img;
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Size = new Size(setting.size, setting.size);
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Click += b_Click;
                b.Tag = s;

                flpSmileys.Controls.Add(b);
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            Smiley s = (Smiley)((Button)sender).Tag;

            Clipboard.SetText(s.Value);
            SetMessage(String.Format("{0} copied to clipboard", s.Name));
        }

        void bottomLabelTimer_Tick(object sender, EventArgs e)
        {
            tssBottom.Text = defaultBottomMsg;
        }

        private void SetMessage(string m)
        {
            tssBottom.Text = m;
            bottomLabelTimer.Stop();
            bottomLabelTimer.Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else
            {
                love += Convert.ToChar(e.KeyValue);

                if (love.Contains("HENRIETTE"))
                {
                    this.Text = "❤️ Henriette ❤️";
                    love = String.Empty;
                }
                else if (love.Length > 20)
                    love = love.Substring(10);
            }
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeButtonSizes(((SizeSetting)cbSize.SelectedItem).intSize);
        }

        private void ChangeButtonSizes(int size)
        {
            foreach (Button b in flpSmileys.Controls)
                b.Size = new Size(size, size);
        }

        private void cbAllwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            setting.alwaysOnTop = this.TopMost = cbAllwaysOnTop.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            setting.size = ((SizeSetting)cbSize.SelectedItem).intSize;
            setting.windowsSize = this.Size;
            Settings.Serialize(setting, settingspath);
        }
    }

    public class SizeSetting
    {
        public int intSize;
        public Size size
        {
            get { return new Size(intSize, intSize); }
        }

        public SizeSetting(int size)
        {
            intSize = size;
        }

        public override string ToString()
        {
            return String.Format("{0}x{0}", intSize);
        }

        public static List<SizeSetting> Sizes()
        {
            List<SizeSetting> l = new List<SizeSetting>();
            l.Add(new SizeSetting(20));
            l.Add(new SizeSetting(30));
            l.Add(new SizeSetting(40));
            l.Add(new SizeSetting(50));
            l.Add(new SizeSetting(60));
            return l;
        }
    }

    public class Smiley
    {
        // http://www.iemoji.com/
        public string Name { get; set; }
        public string Value { get; set; }
        public Image Img { get; set; }

        public Smiley(string Name, string Value, Image Img)
        {
            this.Name = Name;
            this.Value = Value;
            this.Img = Img;
        }

        public static List<Smiley> AllSmileys()
        {
            List<Smiley> l = new List<Smiley>();

            l.Add(new Smiley("SmilingFaceWithOpenMouthAndSmilingEyes", "😄", Properties.Resources.smiling_face_with_open_mouth_and_smiling_eyes));
            l.Add(new Smiley("SmilingFaceWithOpenMouth", "😃", Properties.Resources.smiling_face_with_open_mouth));
            l.Add(new Smiley("GrinningFace", "😀", Properties.Resources.grinning_face));
            l.Add(new Smiley("SmilingFaceWithSmilingEyes", "😊", Properties.Resources.smiling_face_with_smiling_eyes));
            l.Add(new Smiley("WhiteSmilingFace", "☺️", Properties.Resources.white_smiling_face));
            l.Add(new Smiley("WinkingFace", "😉", Properties.Resources.winking_face));
            l.Add(new Smiley("SmilingFaceWIthHeartShapedEyes", "😍", Properties.Resources.smiling_face_with_heart_shaped_eyes));
            l.Add(new Smiley("FaceThrowingAKiss", "😘", Properties.Resources.face_throwing_a_kiss));
            l.Add(new Smiley("KissingFaceWithClosedEyes", "😚", Properties.Resources.kissing_face_with_closed_eyes));
            l.Add(new Smiley("KissingFace", "😗", Properties.Resources.kissing_face));
            l.Add(new Smiley("KissingFaceWithSmilingEyes", "😙", Properties.Resources.kissing_face_with_smiling_eyes));
            l.Add(new Smiley("FaceWithStuckOutTongueAndWinkingEye", "😜", Properties.Resources.face_with_stuck_out_tongue_and_winking_eye));
            l.Add(new Smiley("FaceWithStuckOutTongueAndTightlyClosedEyes", "😝", Properties.Resources.face_with_stuck_out_tongue_and_tightly_closed_eyes));
            l.Add(new Smiley("FaceWithStuckOutTongue", "😛", Properties.Resources.face_with_stuck_out_tongue));
            l.Add(new Smiley("FlushedFace", "😳", Properties.Resources.flushed_face));
            l.Add(new Smiley("GrinningFaceWithSmilingEyes", "😁", Properties.Resources.grinning_face_with_smiling_eyes));
            l.Add(new Smiley("PensiveFace", "😔", Properties.Resources.pensive_face));
            l.Add(new Smiley("RelivedFace", "😌", Properties.Resources.relieved_face));
            l.Add(new Smiley("UnamusedFace", "😒", Properties.Resources.unamused_face));
            l.Add(new Smiley("DisappointedFace", "😞", Properties.Resources.disappointed_face));
            l.Add(new Smiley("PerseveringFace", "😣", Properties.Resources.persevering_face));
            l.Add(new Smiley("CryingFace", "😢", Properties.Resources.crying_face));
            l.Add(new Smiley("FaceWithTearsOfJoy", "😂", Properties.Resources.face_with_tears_of_joy));
            l.Add(new Smiley("LoudlyCryingFace", "😭", Properties.Resources.loudly_crying_face));
            l.Add(new Smiley("SleepyFace", "😪", Properties.Resources.sleepy_face));
            l.Add(new Smiley("DisappointedButRelievedFace", "😥", Properties.Resources.disappointed_but_relieved_face));
            l.Add(new Smiley("FaceWithOpenMouthAndColdSweat", "😰", Properties.Resources.face_with_open_mouth_and_cold_sweat));
            l.Add(new Smiley("SmilingFaceWithOpenMouthAndColdSweat", "😅", Properties.Resources.smiling_face_with_open_mouth_and_cold_sweat));
            l.Add(new Smiley("FaceWithColdSweat", "😓", Properties.Resources.face_with_cold_sweat));
            l.Add(new Smiley("WearyFace", "😩", Properties.Resources.weary_face));
            l.Add(new Smiley("TiredFace", "😫", Properties.Resources.tired_face));
            l.Add(new Smiley("FearfulFace", "😨", Properties.Resources.fearful_face));
            l.Add(new Smiley("FaceScreamingInFear", "😱", Properties.Resources.face_screaming_in_fear));
            l.Add(new Smiley("AngryFace", "😠", Properties.Resources.angry_face));
            l.Add(new Smiley("PoutingFace", "😡", Properties.Resources.pouting_face));
            l.Add(new Smiley("FaceWithLookOfTriumph", "😤", Properties.Resources.face_with_look_of_triumph));
            l.Add(new Smiley("ConfoundedFace", "😖", Properties.Resources.confounded_face));
            l.Add(new Smiley("SmilingFaceWithOpenMouthAndTightlyClosedEyes", "😆", Properties.Resources.smiling_face_with_open_mouth_and_tightly_closed_eyes));
            l.Add(new Smiley("FaceSavouringDeliciousFood", "😋", Properties.Resources.face_savouring_delicious_food));
            l.Add(new Smiley("FaceWithMedicalMask", "😷", Properties.Resources.face_with_medical_mask));
            l.Add(new Smiley("SmilingFaceWithSunglasses", "😎", Properties.Resources.smiling_face_with_sunglasses));
            l.Add(new Smiley("SleepingFace", "😴", Properties.Resources.sleepy_face));
            l.Add(new Smiley("DizzyFace", "😵", Properties.Resources.dizzy_face));
            l.Add(new Smiley("AstonishedFace", "😲", Properties.Resources.astonished_face));
            l.Add(new Smiley("WorriedFace", "😟", Properties.Resources.worried_face));
            l.Add(new Smiley("FrowningFaceWithOpenMouth", "😦", Properties.Resources.frowning_face_with_open_mouth));
            l.Add(new Smiley("AnguishedFace", "😧", Properties.Resources.anguished_face));
            l.Add(new Smiley("SmilingFaceWithHorns", "😈", Properties.Resources.smiling_face_with_horns));
            l.Add(new Smiley("Imp", "👿", Properties.Resources.imp));
            l.Add(new Smiley("FaceWithOpenMouth", "😮", Properties.Resources.face_with_open_mouth));
            l.Add(new Smiley("GrimacingFace", "😬", Properties.Resources.grimacing_face));
            l.Add(new Smiley("NeutralFace", "😐", Properties.Resources.neutral_face));
            l.Add(new Smiley("ConfusedFace", "😕", Properties.Resources.confused_face));
            l.Add(new Smiley("HushedFace", "😯", Properties.Resources.hushed_face));
            l.Add(new Smiley("FaceWithoutMouth", "😶", Properties.Resources.face_without_mouth));
            l.Add(new Smiley("SmilingFaceWithHalo", "😇", Properties.Resources.smiling_face_with_halo));
            l.Add(new Smiley("SmirkingFace", "😏", Properties.Resources.smirking_face));
            l.Add(new Smiley("ExpressionlessFace", "😑", Properties.Resources.expressionless_face));
            l.Add(new Smiley("SeeNoEvilMonkey", "🙈", Properties.Resources.see_no_evil_monkey));
            l.Add(new Smiley("HearNoEvilMonkey", "🙉", Properties.Resources.hear_no_evil_monkey));
            l.Add(new Smiley("SpeakNoEvilMonkey", "🙊", Properties.Resources.speak_no_evil_monkey));
            l.Add(new Smiley("Skull", "💀", Properties.Resources.skull));
            l.Add(new Smiley("ExtraterrestrialFace", "👽", Properties.Resources.extraterrestrial_alien));
            l.Add(new Smiley("PileOfPoo", "💩", Properties.Resources.pile_of_poo));
            l.Add(new Smiley("ThumbsUpSign", "👍", Properties.Resources.thumbs_up_sign));
            l.Add(new Smiley("ThumbsDownSign", "👎", Properties.Resources.thumbs_down_sign));
            l.Add(new Smiley("OKHandSign", "👌", Properties.Resources.ok_hand_sign));
            l.Add(new Smiley("FistedHandSign", "👊", Properties.Resources.fisted_hand_sign));
            l.Add(new Smiley("VictoryHand", "✌️", Properties.Resources.victory_hand));
            l.Add(new Smiley("RaisedFist", "✊", Properties.Resources.raised_fist));
            l.Add(new Smiley("FlexedBiceps", "💪", Properties.Resources.flexed_biceps));
            l.Add(new Smiley("HeavyBlackHeart", "❤️", Properties.Resources.heavy_black_heart));
            l.Add(new Smiley("BrokenHeart", "💔", Properties.Resources.broken_heart));
            l.Add(new Smiley("GrowingHeart", "💗", Properties.Resources.growing_heart));
            l.Add(new Smiley("KissMark", "💋", Properties.Resources.kiss_mark));
            l.Add(new Smiley("MonkeyFace", "🐵", Properties.Resources.monkey_face));
            l.Add(new Smiley("Monkey", "🐒", Properties.Resources.monkey));
            l.Add(new Smiley("PartyPopper", "🎉", Properties.Resources.party_popper));
            l.Add(new Smiley("BeerMug", "🍺", Properties.Resources.beer_mug));
            l.Add(new Smiley("ClinkinBeerMugs", "🍻", Properties.Resources.clinking_beer_mugs));

            return l;
        }
    }
}
