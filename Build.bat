nant

..\NPhilosopher\Obj\nilc Obj\Colorblind.exe > Obj\ColorblindTemp.s
copy Asm\KernelHeader.s+Obj\ColorblindTemp.s+Asm\KernelFooter.s Obj\Colorblind.s
nasm -f bin -o Obj\Colorblind.kernel Obj\Colorblind.s
