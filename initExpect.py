import numpy as np
import random as rnd
import math as math



class initExpect:
    #global variables
    #Opponents Expectaion
    qEx = None
    #Total wins per bid
    BidCount = None
    #Winning bids counter
    pWinBidCount = None
    
    BidValue = None



    #users probability vector
    p = None   
    #Opponents probability vector
    q = None
    
    def __init__(self,qSize=10000):
        #self.calculateExpectation(np.arange(0,1,0.1),10,20)
        self.q = np.zeros(qSize)
        self.p = np.zeros(qSize)
        self.findInitialUserStrategy()
        
        
########################  Just plain rubbish!!!! Jesus        #################
    #The function will raffle a random real number between [0.,1.]
    #if it is less than the given probability in q[i]
    #it will count it as a WINNING BID.
    #The main intention is to immitate a real game with a
    #human opponent.
    def calculateExpectation(self,q, k0,Bid):
        
        #function argument validation
        if (q.size == 0 or k0 == None or k0<1 or Bid == None or Bid <1 ):
            return
        #Initilize arrays 
        size = q.size
        self.qEx = np.zeros(size)
        self.BidCount = np.zeros(size)
        self.pWinBidCount = np.zeros(size)
        #set the bid
        self.BidValue = Bid
        for k in range(k0):
            #calculateExpectation     
            for i in range(size):
                rand = rnd.uniform(0.0,1.0)
                print("the random number is: %f, the q is: %f"%(rand,q[i]))
                if rand <= q[i]:
                    self.BidCount[i]+=1
                    #immitate a win by the User
                    self.pWinBidCount[i]+=1
                    #update expectation
                    self.qEx[i] = self.pWinBidCount[i]*self.BidValue/self.BidCount[i]
                else:
                    break
            print("Expectation Values:")
            print(self.qEx)
            print("q is")
            print(q)
        return
 ##############################################################################   
    
    def singleRoundSimulation(self,i):
        rNum = rnd.uniform(0.0,1.0)
        if( rNum >= self.q[i] ):
            self.p[i]=rNum
            #print("Updating probabilty for %d: %f"%(i,rNum))
            return True
        return False




    def findInitialUserStrategy(self,n0=10,m=3,k0=10,N=1000,y=10,z=5):
        np.set_printoptions(threshold=np.nan,suppress=True)
        #the following class is an implementation that is based
        # on the algorithm that
        #was propesed in the research paper part 1 
        #of our project
        #can be found on page 9 --- Methods
        #first threshold
        for j in range(0,n0):
            #print(self.p)
            for i in range(0,m*k0):
                #check array overflow
                if(self.q.size<=i):
                    break
                #simulate a single round in the game
                if( not self.singleRoundSimulation(i) ):
                    break
        
        #second Threshold -section 2, page 9
        for j in range(0,math.ceil(N/y)):
            for i in range(0,m*j*k0):
                    #check overflow
                    if(self.q.size<=i):
                        print("breaking... %d - %d"%(i,self.q.size))
                        break
                    #simulate a single round in the game
                    if( not self.singleRoundSimulation(i) ):
                        break
            print("Values after the second threshold: ")
           # print(self.p)
            
        #third threshold - section 3 - not done yet
        #need to think how to implement it, since we
        #don't know the expectation yet at this point
        #fourth threshold - section 4
        for j in range(0,math.ceil(N/z)):
            for i in range(0,m*j*k0):
                    #check overflow
                    if(self.q.size<=i):
                        break
                    #simulate a single round in the game
                    if( not self.singleRoundSimulation(i) ):
                        print("didn't find a higher probability, values remain unchanged :\\")
                        break
            print("Values after the 4th threshold: ")
            #print(self.p)
            #Wrtie results to file
            np.savetxt("resultaArr.csv", self.p,fmt="%0.10f", delimiter=",")
            
        
    
test = initExpect()


#should be removed-irrelevant version of the algorithm
#test.calculateExpectation(np.arange(0.1,1,0.1),10000,20)
