import numpy as np


class Algorithm:
    winningExpectations1 = np.zeros([2, 10])
    winningExpectations2 = np.zeros([2, 10])
    winningExpectations = np.zeros([2, 10])
    losingExpectations1 = np.zeros([2, 10])
    losingExpectations2 = np.zeros([2, 10])
    losingExpectations = np.zeros([2, 10])
    # p is the players probabilities table
    p = np.zeros([2, 10])
    # q is the opponents probabilities table
    q = np.zeros([2, 10])
    # algorithm settings variables
    m = 3
    k = 1
    y = 10
    z = 1
    w = 1

    print(winningExpectations1)
    

    def calcualteWinningExpectationAnsdProbability(self, action, state):
        if action:
            if state == 0:
                # this is the first iteration
                for i in range(2):
                    self.p[action, state+i] = 1  # some initial value
                    self.q[action, state+i] = 1  # yes! initial, that's right! :)
                    self.winningExpectations1[action, state+i] = 1
                    self.winningExpectations2[action, state+i] = 1  # ask Zeev about these initial values, according to the research paper it should be a 0

                    self.losingExpectations1[action, state+i] = 1
                    self.losingExpectations2[action, state+i] = 1  # ask Zeev about these initial values, according to the research paper it should be a 0

            if state == 1:
                # this is the second iteration
                for i in range(2, 4):
                    self.p[action, state+i] = 1  # some initial value
                    self.q[action, state+i] = 1  # yes! initial, that's right! :)
                    self.winningExpectations1[action, state+i] = 1
                    self.winningExpectations2[action, state+i] = 1  # ask Zeev about these initial values, according to the research paper it should be a 0
                    self.losingExpectations1[action, state+i] = 1
                    self.losingExpectations2[action, state+i] = 1  # ask Zeev about these initial values, according to the research paper it should be a 0
            else:
                if (2*state+1) > 10:
                    return
                self.winningExpectations1[1, 2 * state] = (  2 * state * self.winningExpectations1[0, 2 * state-1] * self.q[1, 2 * state + 1] * self.p[ 1, 2 * state]*self.q[ 1, 2*state-1])/(  (2*state-2) * (self.q[1, state-1])  )
                self.winningExpectations2[1, 2 * state] = ( (2 * state + 1 - 2 * state - 1) * self.q[1, 2 * state + 1] * self.p[ 1, 2 * state]*self.q[ 1, 2*state-1])/(  (2*state-2) * (self.q[1, state-1])  )
                self.winningExpectations [1, 2 * state] = self.winningExpectations1[1, 2 * state] + self.winningExpectations2[1, 2 * state]

                self.losingExpectations1[1, 2 * state] = (  2 * state * self.winningExpectations1[0, 2 * state-1] * self.p[0, 2 * state] * self.p[ 1, 2 * state - 2]*self.q[ 1, 2*state-1])/(  (2*state-2) * (self.p[1, 2*state-4]) *self.q[1, 2*state-3] )
                self.losingExpectations2[1, 2 * state] = ( (2 * state  +2 - 2 * state ) * self.winningExpectations1[0, 2 * state-1] * self.p[0, 2 * state] * self.p[ 1, 2 * state - 2]*self.q[ 1, 2*state-1])/(  (2*state-2) * (self.p[1, 2*state-4]) *self.q[1, 2*state-3] )
                self.losingExpectations [1, 2 * state] = self.losingExpectations2[1, 2 * state] + self.losingExpectations2[1, 2 * state]
