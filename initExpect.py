import numpy as np
import random as rnd


test = initExpect()
test.calculateExpectation(np.array([0.5,0.25,0.13,0.11]),4)
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
        #just a test
        print ("%f", rand)
        for i in range(0,k0):
            rand  = rnd.uniform(0.0,1.0)
            if rand < q[i]:
                print ("%f is less than %f! Yay!!!", (rand,q[i]))
            else:
                print ("%f is less than %f! Yay!!!", (rand,q[i]))

        
        
    #calculateExpectation(1,1)
    