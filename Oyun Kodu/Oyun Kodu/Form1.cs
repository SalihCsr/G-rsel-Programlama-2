namespace Oyun_Kodu
{
    public partial class Form1 : Form
    {
        private readonly Random _rnd = new Random();
        private int _kalanSn = 60;
        public Form1()
        {
            InitializeComponent();


            // Paneldeki sayi* butonlar�n�n Click olay�n� ortak metoda ba�la
            foreach (var btn in panel1.Controls.OfType<Button>()
                                               .Where(b => b.Name.StartsWith("sayi", StringComparison.OrdinalIgnoreCase)))
            {
                btn.Click += SayiButton_Click;
            }

            //  timer
            timer1.Interval = 1000;


            DurumuSifirla(kumSaatSifirla: true);
        }



        // -- OYUNU B�T�R
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SonucuDegerlendir(manuelBitirme: true);
        }

        // -- OYUNA BA�LA
        private void button1_Click(object sender, EventArgs e)
        {
            DurumuSifirla(kumSaatSifirla: true);

            // 1-100 aras� rastgele (tekrars�z) say�lar� butonlara da��t
            RastgeleSayilariDagit();

            // T�m sayi butonlar�n� aktif et
            foreach (var btn in SayiButonlari())
                btn.Enabled = true;

            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _kalanSn--;
            label2.Text = $"{_kalanSn} sn";

            // Butonlar� panel i�inde rastgele gezdir
            RastgeleYerlestir();

            if (_kalanSn <= 0)
            {
                timer1.Stop();
                SonucuDegerlendir(manuelBitirme: false);
            }
        }

        // === Oyun kurallar� ===
        private void SayiButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && int.TryParse(btn.Text, out int deger))
            {
                listBox1.Items.Add(deger);
                btn.Enabled = false; // ayn� say�y� tekrar se�mesin
                btn.Visible = false; // butonu g�r�nmez yap
            }
        }

        private void SonucuDegerlendir(bool manuelBitirme)
        {
            bool kazandi = KazanmaKosuluSaglandi();

            if (kazandi)
            {
                if (manuelBitirme && _kalanSn <= 5)
                    MessageBox.Show("5 Saniye Kala Oyunu Do�ru Bitirdin", "Tebrikler");
                else
                    MessageBox.Show("Tebrikler, do�ru �ekilde bitirdiniz!", "Kazand�n�z");
            }
            else
            {
                MessageBox.Show("�artlar� sa�layamad�n�z. Kaybettiniz.", "Oyun Bitti");
            }

            DurumuSifirla(kumSaatSifirla: false);
        }

        private bool KazanmaKosuluSaglandi()
        {
            if (listBox1.Items.Count == 0) return false;

            var sayilar = listBox1.Items.Cast<object>()
                                        .Select(o => Convert.ToInt32(o))
                                        .ToList();

            bool hepsiCift = sayilar.All(s => s % 2 == 0);

            bool artanSira = true;
            for (int i = 1; i < sayilar.Count; i++)
            {
                if (sayilar[i] <= sayilar[i - 1])
                {
                    artanSira = false;
                    break;
                }
            }

            return hepsiCift && artanSira;
        }

        // === Yard�mc�lar ===

        // Paneldeki "sayi*" butonlar�n� d�nd�r
        private IEnumerable<Button> SayiButonlari()
        {
            return panel1.Controls.OfType<Button>()
                        .Where(b => b.Name.StartsWith("sayi", StringComparison.OrdinalIgnoreCase));
        }

        // 1-100 aras� TEKRARSIZ rastgele say�lar� butonlara da��t
        private void RastgeleSayilariDagit()
        {
            var butonlar = SayiButonlari().ToList();

            // 1..100 listesini kar��t�r
            var havuz = Enumerable.Range(1, 100).OrderBy(_ => _rnd.Next()).ToList();

            for (int i = 0; i < butonlar.Count; i++)
            {
                int deger = havuz[i];          // tekrars�z
                butonlar[i].Text = deger.ToString();
            }
        }

        private void RastgeleYerlestir()
        {
            int maxX, maxY;

            foreach (var btn in SayiButonlari())
            {
                maxX = Math.Max(0, panel1.ClientSize.Width - btn.Width);
                maxY = Math.Max(0, panel1.ClientSize.Height - btn.Height);

                int x = _rnd.Next(0, maxX + 1);
                int y = _rnd.Next(0, maxY + 1);

                btn.Left = x;
                btn.Top = y;
            }
        }

        private void DurumuSifirla(bool kumSaatSifirla)
        {
            if (kumSaatSifirla)
                _kalanSn = 60;

            label2.Text = $"{_kalanSn} sn";
            listBox1.Items.Clear();

            // sayi butonlar�n� devre d��� b�rak ve (istenirse) yaz�lar�n� temizle
            foreach (var btn in SayiButonlari())
            {
                btn.Enabled = false;
                btn.Text = "";   // yeni oyunda rastgele verilecek
            }

            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void sayi1_Click(object sender, EventArgs e)
        {

        }

        private void sayi2_Click(object sender, EventArgs e)
        {

        }

        private void sayi3_Click(object sender, EventArgs e)
        {

        }

        private void sayi7_Click(object sender, EventArgs e)
        {

        }

        private void sayi4_Click(object sender, EventArgs e)
        {

        }

        private void sayi5_Click(object sender, EventArgs e)
        {

        }

        private void sayi6_Click(object sender, EventArgs e)
        {

        }

        private void sayi9_Click(object sender, EventArgs e)
        {

        }

        private void sayi10_Click(object sender, EventArgs e)
        {

        }

        private void sayi8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

