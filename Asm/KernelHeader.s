; Taken from http://www.osdever.net/tutorials/grub.php

[ORG 0x60000]
[BITS 32]

MULTIBOOT_PAGE_ALIGN   equ 1<<0
MULTIBOOT_MEMORY_INFO  equ 1<<1
MULTIBOOT_AOUT_KLUDGE  equ 1<<16

MULTIBOOT_HEADER_MAGIC equ 0x1BADB002
MULTIBOOT_HEADER_FLAGS equ MULTIBOOT_PAGE_ALIGN | MULTIBOOT_MEMORY_INFO | MULTIBOOT_AOUT_KLUDGE
CHECKSUM               equ -(MULTIBOOT_HEADER_MAGIC + MULTIBOOT_HEADER_FLAGS)

; The Multiboot header
	align 4
mboot:
	dd MULTIBOOT_HEADER_MAGIC
	dd MULTIBOOT_HEADER_FLAGS
	dd CHECKSUM
; fields used if MULTIBOOT_AOUT_KLUDGE is set in MULTIBOOT_HEADER_FLAGS
	dd mboot ; these are PHYSICAL addresses
	dd mboot  ; start of kernel .text (code) section
	dd kernelEnd ; end of kernel .data section
	dd kernelEnd   ; end of kernel BSS
	dd kernelMain ; kernel entry point (initial EIP)

kernelMain:
