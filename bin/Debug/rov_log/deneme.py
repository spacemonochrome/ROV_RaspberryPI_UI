import time
import os
pid = os.getpid()
print("%" + str(pid) + "%" )
for i in range(0, 20):
	print(i)
	time.sleep(1)
print("%bitti%")
