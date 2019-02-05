import sys
import json
import numpy as np
import codecs


#n0,m,y,z,w
def demoFunc():
	print ("This is the name of the script: %s "%sys.argv[0])
	print ("Number of arguments: %s"%len(sys.argv))
	print ("The arguments are: %s"%str(sys.argv))

def demoFuncReadArgs():
	#arr = np.zeros(sys.argv[1])
	arr = np.zeros(1000)
	list = arr.tolist()


	file_path = "/path.json" ## your path variable
	json.dump([{'expectation' : list},{'outcome' : list},{'average' : list}], codecs.open(file_path, 'w', encoding='utf-8'), separators=(',', ':'), sort_keys=True, indent=4) ### this saves the array in .json forma


	str = json.dumps([{'array' : list}] )
	print(str)
	print ("This is the name of the script: "%sys.argv[0])
	print ("Number of arguments: "%len(sys.argv))
	print ("The arguments are: %s %s %s %s %s"%(str(sys.argv[1]),str(sys.argv[2]),str(sys.argv[3]),str(sys.argv[4]),str(sys.argv[5])))


class jsonWrapper:
	def createJsonFromArrays(self,expectation, outcome, average ):
		#the following method wraps the arrays in json, and sends them via the Standard Input output
		file_path = "/path.json" ## your path variable
		#write a copy of the json file to a file, for validation.
		jsonDump = json.dump([{'expectation' : expectation.tolist() } , {'outcome' : outcome.tolist()},{'average' : average.tolist() }], codecs.open(file_path, 'w', encoding='utf-8'), separators=(',', ':'), sort_keys=True, indent=4) ### this saves the array in .json for
		
		#generate the json object and printing it to the standrad input output.
		jsonDump = json.dump([{'expectation' : expectation.tolist() } , {'outcome' : outcome.tolist()},{'average' : average.tolist() }], sys.stdout, separators=(',', ':'), sort_keys=False, indent=4) ### this saves the array in .json forma	
		print("This was the JS
ON Object.")
	
print("Just called a python process :) ")
#demoFunc()
#demoFuncReadArgs()
JSONWrapper = jsonWrapper()
JSONWrapper.createJsonFromArrays(np.zeros(1000) , np.zeros(1000) , np.zeros(1000) )