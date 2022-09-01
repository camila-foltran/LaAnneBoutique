using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace loja
{
    class Elgin
    {
        [DllImport("ElginCupom.dll")]
        public static extern short ElginCupom_AcionaGaveta();

        [DllImport("ElginCupom.dll")]
        public static extern short ElginCupom_AcionaGuilhotina(short modo);

        [DllImport("ElginCupom.dll")]
        public static extern int ElginCupom_EnviaBufferFormatado(string Buffer, int TipoLetra, int Italico, int Sublinhado, int Expandido, int Enfatizado);

        [DllImport("ElginCupom.dll")]
        public static extern short ElginCupom_EnviaBuffer(string buffer);

        [DllImport("ElginCupom.dll")]
        public static extern short ElginCupom_VerificaOnLine();


    }
}
