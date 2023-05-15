using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace VoiceAssistant
{
    public partial class frmVoiceAssistant : Form
    {
        private SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();

        private SpeechSynthesizer VoiceAssistant = new SpeechSynthesizer();

        private SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();
        private Random rnd = new Random();
        private int RecTimeOut = 0;
        private DateTime timeNow = DateTime.Now;
        private bool recognizerOn = true;

        public frmVoiceAssistant()
        {
            InitializeComponent();
        }

        private void frmVoiceAssistant_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFiles\DefaultCommands.txt")))));
            _recognizer.RequestRecognizerUpdate();
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            VoiceAssistant.SpeakStarted += VoiceAssistant_SpeakStarted;
            VoiceAssistant.SpeakCompleted += VoiceAssistant_SpeakCompleted;

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFiles\DefaultCommands.txt")))));
            _recognizer.RequestRecognizerUpdate();
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);
        }

        private void VoiceAssistant_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            recognizerOn = true;
        }

        private void VoiceAssistant_SpeakStarted(object? sender, SpeakStartedEventArgs e)
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
                    case "Hi assistant":
                        VoiceAssistant.SpeakAsync("Hi boss" + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;

                    case "How are you?":
                        VoiceAssistant.SpeakAsync("I'm working for you" + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;

                    case "What time is it?":
                        VoiceAssistant.SpeakAsync(DateTime.Now.ToString("h mm tt") + "....");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        break;

                    case "Stop talking":
                        ranNum = rnd.Next(1, 2);
                        if (ranNum == 1)
                        {
                            VoiceAssistant.SpeakAsync("Yes, boss" + "......");
                            lblRecognizer.Text = "";
                            lblRecognizer.Text = speech;
                        }
                        else if (ranNum == 2)
                        {
                            VoiceAssistant.SpeakAsync("OK, I'll be quiet" + "......");
                            lblRecognizer.Text = "";
                            lblRecognizer.Text = speech;
                        }
                        break;

                    case "Stop listening":
                        VoiceAssistant.SpeakAsync("Call me if you need me");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        _recognizer.RecognizeAsyncCancel();
                        startListening.RecognizeAsync(RecognizeMode.Multiple);
                        break;

                    case "Play my favorite song":
                        VoiceAssistant.SpeakAsync("Playing Purrito APA on YouTube");
                        lblRecognizer.Text = "";
                        lblRecognizer.Text = speech;
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "chrome.exe",
                            Arguments = "https://www.youtube.com/watch?v=x4rMUIXoyhE",
                            UseShellExecute = true
                        });
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

        private void startListening_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            switch (speech)
            {
                case "Wake up":
                    startListening.RecognizeAsyncCancel();
                    VoiceAssistant.SpeakAsync("Yes boss?");
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