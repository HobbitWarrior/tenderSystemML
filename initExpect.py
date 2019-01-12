import numpy as np
import random as rnd



class initExpect:
    #global variables
    #Opponents Expectaion
    qEx = None
    #Total wins per bid
    BidCount = None
    #Winning bids counter
    pWinBidCount = None
    
    
    def __init__(self):
        self.calculateExpectation(10,10)
        #TBD

    #The function will raffle a random real number between [0.,1.]
    #if it is less than the given probability in q[i]
    #it will count it as a WINNING BID.
    #The main intention is to immitate a real game with a
    #human opponent.
    def calculateExpectation(self,q, k0):
        rand = rnd.uniform(0.0,1.0)
        print(rand)
        for i in range(10):
            rand = rnd.uniform(0.0,1.0)
            print("%d : %f"%(i+1,rand))
            print(q)
            if rand <= 1:
                print("its less LOL")
        
        return
        
        
    #calculateExpectation(1,1)
test = initExpect()

test.calculateExpectation(np.arange(0,1,0.1),4)
