import sys


#n0,m,y,z,w
def demoFunc():
	print ("This is the name of the script: %s "%sys.argv[0])
	print ("Number of arguments: %s"%len(sys.argv))
	print ("The arguments are: %s"%str(sys.argv))

def demoFunReadArgs():
	print ("This is the name of the script: "%sys.argv[0])
	print ("Number of arguments: "%len(sys.argv))
	print ("The arguments are: %s %s %s %s %s"%(str(sys.argv[1]),str(sys.argv[2]),str(sys.argv[3]),str(sys.argv[4]),str(sys.argv[5])))
	
	
print("Just called a python process :) ")
demoFunc()
demoFuncReadArgs()