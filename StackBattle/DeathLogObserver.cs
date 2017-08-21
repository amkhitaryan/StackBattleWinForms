using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StackBattle
{
    [Serializable]
    class DeathLogObserver : IObserver
    {
        public async void Update()
        {
            using (StreamWriter sw = new StreamWriter("D:\\Desktop\\DeathLogFile.txt", true, Encoding.UTF8))
            {
                string text = (DateTime.Now + " a Cleric has died");
                Task writeTask = sw.WriteLineAsync(text.ToCharArray(), 0, text.Length);
                await writeTask;
            }
        }
    }
}
