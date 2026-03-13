using Microsoft.VisualBasic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;

namespace Shoot_Out_Game_MOO_ICT
{
    public class GerenciadorDeAudio
    {
        private WaveOutEvent outputDevice;
        private MixingSampleProvider mixer;

        public GerenciadorDeAudio()
        {
            outputDevice = new WaveOutEvent();

            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
            mixer.ReadFully = true;

            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public void TocarSom(Stream audioResourceStream)
        {
            var memoryStream = new MemoryStream();
            audioResourceStream.CopyTo(memoryStream);
            memoryStream.Position = 0;

            var waveReader = new WaveFileReader(memoryStream);

            ISampleProvider sampleProvider = waveReader.ToSampleProvider();

            if (sampleProvider.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                sampleProvider = new MonoToStereoSampleProvider(sampleProvider);
            }

            if (sampleProvider.WaveFormat.SampleRate != mixer.WaveFormat.SampleRate)
            {
                sampleProvider = new WdlResamplingSampleProvider(sampleProvider, mixer.WaveFormat.SampleRate);
            }

            mixer.AddMixerInput(sampleProvider);
        }

        public void Encerrar()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
        }
    }
}