# date: 2024-01-26
# link: https://www.youtube.com/watch?v=KEYzUP7-kkU&list=PL_r4rS7sBXUJUBmoPra9vMKZ6clpg_tdO&index=2

import cv2
import numpy as np

sample_movie = './data/test2.mp4'

video = cv2.VideoCapture(sample_movie)

while True:
	ret, frame = video.read()
	
	hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
	low_yellow = np.array([18, 100, 90])
	up_yellow = np.array([40, 255, 255])
	mask = cv2.inRange(hsv, low_yellow, up_yellow)

	if not ret:
		video = cv2.VideoCapture(sample_movie)
		continue 

	cv2.imshow('frame', frame)
	cv2.imshow('mask', mask)

	key = cv2.waitKey(25) 
	if key == 27: # esc키
		break

video.release()
cv2.destroyAllWindows()