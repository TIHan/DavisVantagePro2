using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

/*
u8 const GreenDot_Table[256] =
{
	0x00, 0x04, 0x08, 0x0C, 0x10, 0x14, 0x18, 0x1C, 0x21, 0x25, 0x29, 0x2D, 0x31, 0x35, 0x39, 0x3D,
	0x46, 0x42, 0x4E, 0x4A, 0x56, 0x52, 0x5E, 0x5A, 0x67, 0x63, 0x6F, 0x6B, 0x77, 0x73, 0x7F, 0x7B, 
	0x8C, 0x88, 0x84, 0x80, 0x9C, 0x98, 0x94, 0x90, 0xAD, 0xA9, 0xA5, 0xA1, 0xBD, 0xB9, 0xB5, 0xB1, 
	0xCA, 0xCE, 0xC2, 0xC6, 0xDA, 0xDE, 0xD2, 0xD6, 0xEB, 0xEF, 0xE3, 0xE7, 0xFB, 0xFF, 0xF3, 0xF7,
	0x18, 0x1C, 0x10, 0x14, 0x08, 0x0C, 0x00, 0x04, 0x39, 0x3D, 0x31, 0x35, 0x29, 0x2D, 0x21, 0x25,
	0x5E, 0x5A, 0x56, 0x52, 0x4E, 0x4A, 0x46, 0x42, 0x7F, 0x7B, 0x77, 0x73, 0x6F, 0x6B, 0x67, 0x63,
	0x94, 0x90, 0x9C, 0x98, 0x84, 0x80, 0x8C, 0x88, 0xB5, 0xB1, 0xBD, 0xB9, 0xA5, 0xA1, 0xAD, 0xA9,
	0xD2, 0xD6, 0xDA, 0xDE, 0xC2, 0xC6, 0xCA, 0xCE, 0xF3, 0xF7, 0xFB, 0xFF, 0xE3, 0xE7, 0xEB, 0xEF,
	0x31, 0x35, 0x39, 0x3D, 0x21, 0x25, 0x29, 0x2D, 0x10, 0x14, 0x18, 0x1C, 0x00, 0x04, 0x08, 0x0C,
	0x77, 0x73, 0x7F, 0x7B, 0x67, 0x63, 0x6F, 0x6B, 0x56, 0x52, 0x5E, 0x5A, 0x46, 0x42, 0x4E, 0x4A,
	0xBD, 0xB9, 0xB5, 0xB1, 0xAD, 0xA9, 0xA5, 0xA1, 0x9C, 0x98, 0x94, 0x90, 0x8C, 0x88, 0x84, 0x80,
	0xFB, 0xFF, 0xF3, 0xF7, 0xEB, 0xEF, 0xE3, 0xE7, 0xDA, 0xDE, 0xD2, 0xD6, 0xCA, 0xCE, 0xC2, 0xC6,
	0x29, 0x2D, 0x21, 0x25, 0x39, 0x3D, 0x31, 0x35, 0x08, 0x0C, 0x00, 0x04, 0x18, 0x1C, 0x10, 0x14,
	0x6F, 0x6B, 0x67, 0x63, 0x7F, 0x7B, 0x77, 0x73, 0x4E, 0x4A, 0x46, 0x42, 0x5E, 0x5A, 0x56, 0x52,
	0xA5, 0xA1, 0xAD, 0xA9, 0xB5, 0xB1, 0xBD, 0xB9, 0x84, 0x80, 0x8C, 0x88, 0x94, 0x90, 0x9C, 0x98,
	0xE3, 0xE7, 0xEB, 0xEF, 0xF3, 0xF7, 0xFB, 0xFF, 0xC2, 0xC6, 0xCA, 0xCE, 0xD2, 0xD6, 0xDA, 0xDE
};

u8 const Adesto_Factory_Programmed[64] = 
{
	// put here AT45DB011D Security Register from byte 64 to 127
};

u8 OneTime_User_Programmable[64];

OneTime_User_Programmable[0] = 0x00; // or whatever you want
OneTime_User_Programmable[1] = 0x00; // or whatever you want
OneTime_User_Programmable[2] = 0x00; // or whatever you want

u8 n, value;

for(n=3;n<64;n++)
{
	value = (u8)(Adesto_Factory_Programmed[n] + n);
	OneTime_User_Programmable[n] = GreenDot_Table[value];
}
*/

namespace DavisVantagePro2
{
	class MainClass
	{
		const byte CMD_STATUS = 0xD7;
		const byte CMD_SECURITY = 0x77;
		const byte RESPONSE_STATUS = 0x8C;

		static byte[] greenDot =
		{
			0x00, 0x04, 0x08, 0x0C, 0x10, 0x14, 0x18, 0x1C, 0x21, 0x25, 0x29, 0x2D, 0x31, 0x35, 0x39, 0x3D,
			0x46, 0x42, 0x4E, 0x4A, 0x56, 0x52, 0x5E, 0x5A, 0x67, 0x63, 0x6F, 0x6B, 0x77, 0x73, 0x7F, 0x7B, 
			0x8C, 0x88, 0x84, 0x80, 0x9C, 0x98, 0x94, 0x90, 0xAD, 0xA9, 0xA5, 0xA1, 0xBD, 0xB9, 0xB5, 0xB1, 
			0xCA, 0xCE, 0xC2, 0xC6, 0xDA, 0xDE, 0xD2, 0xD6, 0xEB, 0xEF, 0xE3, 0xE7, 0xFB, 0xFF, 0xF3, 0xF7,
			0x18, 0x1C, 0x10, 0x14, 0x08, 0x0C, 0x00, 0x04, 0x39, 0x3D, 0x31, 0x35, 0x29, 0x2D, 0x21, 0x25,
			0x5E, 0x5A, 0x56, 0x52, 0x4E, 0x4A, 0x46, 0x42, 0x7F, 0x7B, 0x77, 0x73, 0x6F, 0x6B, 0x67, 0x63,
			0x94, 0x90, 0x9C, 0x98, 0x84, 0x80, 0x8C, 0x88, 0xB5, 0xB1, 0xBD, 0xB9, 0xA5, 0xA1, 0xAD, 0xA9,
			0xD2, 0xD6, 0xDA, 0xDE, 0xC2, 0xC6, 0xCA, 0xCE, 0xF3, 0xF7, 0xFB, 0xFF, 0xE3, 0xE7, 0xEB, 0xEF,
			0x31, 0x35, 0x39, 0x3D, 0x21, 0x25, 0x29, 0x2D, 0x10, 0x14, 0x18, 0x1C, 0x00, 0x04, 0x08, 0x0C,
			0x77, 0x73, 0x7F, 0x7B, 0x67, 0x63, 0x6F, 0x6B, 0x56, 0x52, 0x5E, 0x5A, 0x46, 0x42, 0x4E, 0x4A,
			0xBD, 0xB9, 0xB5, 0xB1, 0xAD, 0xA9, 0xA5, 0xA1, 0x9C, 0x98, 0x94, 0x90, 0x8C, 0x88, 0x84, 0x80,
			0xFB, 0xFF, 0xF3, 0xF7, 0xEB, 0xEF, 0xE3, 0xE7, 0xDA, 0xDE, 0xD2, 0xD6, 0xCA, 0xCE, 0xC2, 0xC6,
			0x29, 0x2D, 0x21, 0x25, 0x39, 0x3D, 0x31, 0x35, 0x08, 0x0C, 0x00, 0x04, 0x18, 0x1C, 0x10, 0x14,
			0x6F, 0x6B, 0x67, 0x63, 0x7F, 0x7B, 0x77, 0x73, 0x4E, 0x4A, 0x46, 0x42, 0x5E, 0x5A, 0x56, 0x52,
			0xA5, 0xA1, 0xAD, 0xA9, 0xB5, 0xB1, 0xBD, 0xB9, 0x84, 0x80, 0x8C, 0x88, 0x94, 0x90, 0x9C, 0x98,
			0xE3, 0xE7, 0xEB, 0xEF, 0xF3, 0xF7, 0xFB, 0xFF, 0xC2, 0xC6, 0xCA, 0xCE, 0xD2, 0xD6, 0xDA, 0xDE
		};

		static byte[] adestoFactoryProgrammed = new byte[64];
		static byte[] oneTimeUserProgrammable = new byte[64];

		public static List<byte> Init ()
		{
			var rnd = new Random ();

			rnd.NextBytes (adestoFactoryProgrammed);

			oneTimeUserProgrammable [0] = 0x00;
			oneTimeUserProgrammable [1] = 0x00;
			oneTimeUserProgrammable [2] = 0x00;

			for (byte i = 3; i < 64; ++i)
			{
				var value = adestoFactoryProgrammed [i] + i;
				oneTimeUserProgrammable [i] = greenDot [value];
			}

			var data = oneTimeUserProgrammable.ToList ();
			data.AddRange (adestoFactoryProgrammed.ToList ());
			return data;
		}

		public static void Main (string[] args)
		{
			var table = Init ();

			var dvp2 = new SerialPort("/dev/ttyAMA0", 19200, Parity.None, 8, StopBits.One);
			dvp2.Open ();

			var cmd = Encoding.ASCII.GetBytes ("TEST\n").ToList ();
			var newCmd = cmd.Select (x => table [x]);

			//Encoding.ASCII.GetString (newCmd.ToArray ())
			//dvp2.Write("TEST\n");
			dvp2.Write (Encoding.ASCII.GetString (newCmd.ToArray ()));

			System.Threading.Thread.Sleep (1000);
			if (dvp2.BytesToRead > 0)
				Console.WriteLine (dvp2.ReadExisting ());

			dvp2.Close ();
		}
	}
}
