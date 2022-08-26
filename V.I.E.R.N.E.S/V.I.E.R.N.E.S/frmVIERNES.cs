using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace F.R.I.D.A.Y
{
    public partial class frmVIERNES : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();

        SpeechSynthesizer Viernes = new SpeechSynthesizer();

        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime timeNow = DateTime.Now;
        bool recognizerOn = true;

        public frmVIERNES()
        {
            InitializeComponent();
        }

        private void frmFRIDAY_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFiles\ComandosPorDefecto.txt")))));
            _recognizer.RequestRecognizerUpdate();
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            Viernes.SpeakStarted += Viernes_SpeakStarted;
            Viernes.SpeakCompleted += Viernes_SpeakCompleted;

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFiles\ComandosPorDefecto.txt")))));
            _recognizer.RequestRecognizerUpdate();
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
        }

        private void Viernes_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            recognizerOn = true;
        }

        private void Viernes_SpeakStarted(object? sender, SpeakStartedEventArgs e)
        {
            recognizerOn = false;
        }

        private void Default_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            if (recognizerOn == true)
            {
                switch (speech)
                {
                    case "Hola Viernes":
                        Viernes.SpeakAsync("Hola Juan José" + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;
                    case "¿Cómo estas?":
                        Viernes.SpeakAsync("Trabajando para usted" + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;
                    case "¿Qué hora es?":
                        Viernes.SpeakAsync(DateTime.Now.ToString("h mm tt") + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;
                    case "Deja de hablar":
                        ranNum = rnd.Next(1, 2);
                        if (ranNum == 1)
                        {
                            Viernes.SpeakAsync("Si, Señor Juan" + "......");
                            lblRecognizer.Text = "";
                            lblRecognizer.Text = speech;
                        }
                        else if (ranNum == 2)
                        {
                            Viernes.SpeakAsync("Esta bien, me mantendré callada" + "......");
                            lblRecognizer.Text = "";
                            lblRecognizer.Text = speech;

                        }
                        break;
                    case "Deja de escuchar":
                        Viernes.SpeakAsync("Si me necesitas, solo llamame");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        _recognizer.RecognizeAsyncCancel();
                        startListening.RecognizeAsync(RecognizeMode.Multiple);
                        break;
                    case "Pon mi canción favorita":
                        Viernes.SpeakAsync("Colocando Purrito apa" + "......");
                        Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://www.youtube.com/watch?v=x4rMUIXoyhE&ab_channel=FeidVEVO");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;

                    default:
                        break;
                }

            }
        }
        private void _recognizer_SpeechRecognized(object? sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }
        private void startlistening_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            switch (speech)
            {
                case "Despierta":
                    startListening.RecognizeAsyncCancel();
                    Viernes.SpeakAsync("¿Si? Señor Juan");
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    lblRecognizer.Text = "";
                    lblRecognizer.Text = speech;
                    break;
                default:
                    break;
            }
        }

        private void tmrSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                tmrSpeaking.Stop();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }

        private void lstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}