using System;

namespace Colorblind.Common.PointerTypes {
	public interface IPointer<T> {
		ulong Addr {
			get;
			set;
		}
		
		T Value {
			get;
			set;
		}
	}
	
	abstract unsafe public class BasePointer {
		protected bool Is64;
		
		public BasePointer() {
			Is64 = sizeof(void *) == sizeof(ulong);
		}
	}
	
	unsafe public class BytePointer : BasePointer, IPointer<Byte> {
		private byte *Ptr = null;
		
		public ulong Addr {
			get {
				return (ulong) Ptr;
			}
			set {
				if(Is64)
					Ptr = (byte *) value;
				else
					Ptr = (byte *) (uint) value;
			}
		}
		
		public byte Value {
			get {
				return *Ptr;
			}
			set {
				*Ptr = value;
			}
		}
	}
	
	unsafe public class UShortPointer : BasePointer, IPointer<ushort> {
		private ushort *Ptr = null;
		
		public ulong Addr {
			get {
				return (ulong) Ptr;
			}
			set {
				if(Is64)
					Ptr = (ushort *) value;
				else
					Ptr = (ushort *) (uint) value;
			}
		}
		
		public ushort Value {
			get {
				return *Ptr;
			}
			set {
				*Ptr = value;
			}
		}
	}
	
	unsafe public class UIntPointer : BasePointer, IPointer<uint> {
		private uint *Ptr = null;
		
		public ulong Addr {
			get {
				return (ulong) Ptr;
			}
			set {
				if(Is64)
					Ptr = (uint *) value;
				else
					Ptr = (uint *) (uint) value;
			}
		}
		
		public uint Value {
			get {
				return *Ptr;
			}
			set {
				*Ptr = value;
			}
		}
	}
	
	unsafe public class ULongPointer : BasePointer, IPointer<ulong> {
		private ulong *Ptr = null;
		
		public ulong Addr {
			get {
				return (ulong) Ptr;
			}
			set {
				if(Is64)
					Ptr = (ulong *) value;
				else
					Ptr = (ulong *) (uint) value;
			}
		}
		
		public ulong Value {
			get {
				return *Ptr;
			}
			set {
				*Ptr = value;
			}
		}
	}
}
