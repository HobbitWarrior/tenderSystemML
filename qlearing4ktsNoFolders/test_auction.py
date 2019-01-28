from keras.models import Sequential
from keras.layers import Flatten, Dense
from auction import Auction
from keras.optimizers import *
from agent import Agent


from keras import backend as K
K.set_image_dim_ordering('th')

grid_size = 2000
nb_frames = 1000
nb_actions = 2

hidden_size = 100

numberOfPerliminaryGames = 100
isUserFirst = False
maxPMoves = 1000

model = Sequential()
model.add(Flatten(input_shape=(nb_frames, grid_size, grid_size)))
model.add(Dense(hidden_size, activation='relu'))
model.add(Dense(hidden_size, activation='relu'))
model.add(Dense(3))
model.compile(sgd(lr=.2), "mse")

auction = Auction(isUserFirst,numberOfPerliminaryGames,maxPMoves,None,grid_size)
agent = Agent(model=model, memory_size=-1, nb_frames=nb_frames)
agent.train(auction, batch_size=64, nb_epoch=10000, gamma=0.8)
agent.play(auction)
