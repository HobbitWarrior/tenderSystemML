import numpy as np
from game import Game

class Auction(Game):
    
    q = None
    p = None
    userOutcome = None
    opponentOutcome = None
    EUser = None
    EOpponent = None
    gameOver = False
    isUserWon = False
    K = 1000
    step = 1
    
    def __init__(self,isFirst=False,N=100,maxMove=1000,opponenetOutcome=None,K=2000):
        self.reset()
    @property
    def name(self):
        return "Auction"
	
    """Returns: how many auctions the game has: bid, pass"""
    @property
    def nb_actions(self):
        return 2
	
    
    """Resets the game, TODO: Further explanation later-TBD :P """
    def reset(self):
        #default game setting
        self.calculateOutcome()
    """Implemention of a game play, we define a game play as two moves, the player's move and the opponent's response,
        players move order can change. """    
    def play(self, action):
		#Decided to pass
        if not action:
            self.passGame()
         #Did we reach our investing capital limit?
        elif self.step > self.K:
             self.passGame()
        elif  self.calculateExpecation() < (self.K - self.step):
            self.passGame()
        else:
            self.step+=1
            
            


    def get_state(self):
        return self.userOutcome

    def get_score(self):
        return (self.K-self.step)

    def is_over(self):
        return self.gameOver

    def is_won(self):
        return self.isUserWon

    def get_frame(self):
        return self.get_state()

    def draw(self):
        return self.get_state()

    def get_possible_actions(self):
        return range(self.nb_actions)
    
    
    
    
    
    
    def passGame(self):
        self.isUserWon = False
        self.gameOver = True
        return
    
    """ Calculates the possible expectation from the auction so far,
        Since Since the opponents possible move is considered an hidden information
        we do not include its calculation, or even consider it in our decision making at this
        phase.
        Returns:
            Expactations[step]."""
    def calculateExpecation(self):
        self.EUser[self.step] = ( self.userOutcome[self.step]*self.p[self.step] + (-self.step)*self.p[self.step] ) * ( 1 if self.step==1 else self.EUser[self.step-2] )
        return self.EUser[self.step]
        
    
    
    def calculateOutcome(self,isFirst=False,N=100,maxMove=1000,opponenetOutcome=None,K=2000):
        self.userOutcome = np.zeros(maxMove)
        
        self.q = np.arange(0.0001,1,0.0001)
        self.p = np.zeros(maxMove)
        
        #toggling the turn of the user
        #based on the input parameter: boolean isFirst
        usersTurn = isFirst^1
        
        if self.opponentOutcome is None:
            self.opponentOutcome = np.zeros(maxMove)
            #print(self.opponentOutcome.size)
        for i in range(0,N):
            for iMove in range(0,maxMove):
                if(iMove%2 == usersTurn):
                    usersMove = np.random.uniform(0.0,1.0)
                    if(usersMove>self.q[iMove]):
                        #User won
                        #save the current probability,
                        #since it will be beneficial for the user to play this round
                        self.p[iMove] = usersMove
                        #keep setting the entire outcome vector to the max,
                        #ie. simulate a win of the user in the entire rounds
                        #from this point on.
                        for j in range(iMove,maxMove):
                            self.userOutcome[j]=self.userOutcome[j]+K-(iMove-1)
                            self.opponentOutcome[j]=self.opponentOutcome[j]-(iMove-2)
                            #exit the current game :P jeez this shit is effing ridiculous
                            break
                else:
                    opponentsMove = np.random.uniform(0.0,1.0)
                    if opponentsMove>self.p[iMove]:
                        #simulates a win by the opponent
                        #Since the opponent won, 
                        #set user's probility vector in this index to the 
                        #opponent's random probability value complement
                        self.p[iMove]=1-opponentsMove
                        
                        for j in range(iMove,maxMove):
                            self.opponentOutcome[j]=self.opponentOutcome[j]+K-(iMove-1)
                            self.userOutcome[j]=self.userOutcome[j]-(iMove-2)
                            #exit the current game :P jeez this shit is effing ridiculous
                            break
