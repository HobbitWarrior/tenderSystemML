#import tensorflow.keras as keras
import tensorflow as tf

import matplotlib.pyplot as plt

import numpy as np


print(tf.__version__)

mnist = tf.keras.datasets.mnist
(x_train, y_train),(x_test, y_test) = mnist.load_data()
print(x_train[0])


plt.imshow(x_train[0],cmap=plt.cm.binary)
plt.show()
print(y_train[0])
x_train = tf.keras.utils.normalize(x_train, axis=1)
x_test = tf.keras.utils.normalize(x_test, axis=1)

print(x_train[0])

plt.imshow(x_train[0],cmap=plt.cm.binary)
plt.show()


model = tf.keras.models.Sequential()
model.add(tf.keras.layers.Flatten())# convert to a single dimension, from 28x28 to 1x784


#layers, the first parameter is the #of units, the second is the activation function
model.add(tf.keras.layers.Dense(128, activation=tf.nn.relu))
model.add(tf.keras.layers.Dense(128, activation=tf.nn.relu))

model.add(tf.keras.layers.Dense(10, activation=tf.nn.softmax))

model.compile(optimizer='adam',
              loss='sparse_categorical_crossentropy',
              metrics=['accuracy'])
model.fit(x_train, y_train, epochs=3)

val_loss, val_acc = model.evaluate(x_test, y_test)  # evaluate the out of sample data with model
print(val_loss)  # model's loss (error)
print(val_acc)  # model's accuracy

#model.save('epic_num_reader.model')
#new_model = tf.keras.models.load_model('epic_num_reader.model')
predictions = model.predict(x_test)
print(predictions)



plt.imshow(x_test[0],cmap=plt.cm.binary)
plt.show()

print(np.argmax(predictions[0]))