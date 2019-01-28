from keras.models import Sequential
from keras.layers import Flatten, Dense
from keras.optimizers import *
from agent import Agent
from auction import Auction

import numpy as np

from keras import backend as K
K.set_image_dim_ordering('th')

grid_size = 2000
nb_frames = 1
nb_actions = 2

hidden_size = 100

numberOfPerliminaryGames = 100
isUserFirst = False
maxPMoves = 2000

model = Sequential()
#                           How many steps  number   number 
#                           to remember   , of cols , of rows

model.add(Flatten(input_shape=(nb_frames, 1, np.ceil(maxPMoves/2).astype('int'))))
model.add(Dense(hidden_size, activation='relu'))
model.add(Dense(hidden_size, activation='relu'))
model.add(Dense(3))
model.compile(sgd(lr=.2), "mse")

auction = Auction(isUserFirst,numberOfPerliminaryGames,maxPMoves,None,grid_size)
agent = Agent(model=model)
agent.train(auction, batch_size=10, nb_epoch=1000, epsilon=.1)
agent.play(auction)
