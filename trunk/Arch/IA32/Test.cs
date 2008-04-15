class Test {
	public static int X, Y;
	
	unsafe static void Memcpy(byte *from, byte *to, int size) {
		while(size-- != 0)
			*(to++) = *(from++);
	}
	
	unsafe static void Memset(byte *to, byte value, int size) {
		while(size-- != 0)
			*(to++) = value;
	}
	
	unsafe static void NewLine() {
		X = 0;
		if(++Y == 25) {
			int off = 80 * 2;
			Memcpy((byte *) 0xB8000U + off, (byte *) 0xB8000U, (80 * 25 * 2) - off);
			Y = 24;
		}
		Memset((byte *) 0xB8000U + (Y * 80 * 2), 0, 80 * 2);
	}
	
	unsafe static void PutChar(char ch) {
		byte *ptr = (byte *) 0xB8000U + (Y * 160) + (X * 2);
		ptr[0] = (byte) ch;
		ptr[1] = 0x0F;
		
		if(++X == 80)
			NewLine();
	}
	
	unsafe static public void Main() {
		Memset((byte *) 0xB8000U, 0, 80*25*2);
		while(true) {
			for(int i = 0; i < 160; ++i) {
				for(int j = 0; j < i; ++j)
					PutChar(' ');
				PutChar('C');
				PutChar('o');
				PutChar('l');
				PutChar('o');
				PutChar('r');
				PutChar('B');
				PutChar('l');
				PutChar('i');
				PutChar('n');
				PutChar('d');
				NewLine();
			}
		}
	}
}
