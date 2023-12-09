# MultiSourceFileCopy_WithGUI

I have the idea that by dividing a file up into page sized chunks that those chunks could be more efficiently read and written.

Some things that this utility aims for:
allow multiple file sources to be chosen with a file picker and write the files using multithreading, over multiple transport mediums to accelerate file copy.
Have the destination for the files be multi-targeting too. This is done by reading blocks of IP addresses in a text file and separating them using a separation line.
I was thinking it would be useful for business to be able to specify ranges of IP addresses for departments and have the socket server repeat at the destination. The packets
it's recieving for the other computers in the same block.

I've brought in my socket client and server code and have written the code to split the files up.

Some information that relates to the project:
NAND flash memory only ever reads and writes in 4KB pages. Also 4KB file alignment is common in NTFS.
I have code to rewrite fileinfo as a check for after the files are written. Changing the datetime of the assembled data
to be current time for read, access and create.

a lot of the code needed to finish this is in other projects I've already written and are in my github repos.
It just takes time to bring it all together and then debug it.

Any interest or especially help is welcome.
