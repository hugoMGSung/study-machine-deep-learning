# date : 2024-01-26
# ref : https://www.youtube.com/watch?v=KEYzUP7-kkU&list=PL_r4rS7sBXUJUBmoPra9vMKZ6clpg_tdO&index=2

import cv2
import numpy as np

## Test
def remove_grabcut_bg(image):
	tmp = cv2.cvtColor(image,cv2.COLOR_RGB2GRAY)
	_,alpha = cv2.threshold(tmp,0,255,cv2.THRESH_BINARY)
	r, g, b = cv2.split(image)
	rgba = [r,g,b,alpha]
	dst = cv2.merge(rgba,4)
	return dst

# img = cv2.imread('./data/U2PZu1679322052.jpg')
# resized_img_1 = cv2.resize(img, dsize=(1024,768), interpolation=cv2.INTER_LINEAR)
# cv2.imshow('Image', resized_img_1)

img = cv2.imread('./data/lines.png')
# image = remove_grabcut_bg(img)
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
edges = cv2.Canny(gray, 75, 150)

lines = cv2.HoughLinesP(edges, 1, np.pi/180, 100, maxLineGap=150)

for line in lines:
	x1, y1, x2, y2 = line[0]
	cv2.line(img, (x1, y1), (x2, y2), (0,255,0), 3)

cv2.imshow('Edges', edges)
cv2.imshow('Images', img)
cv2.waitKey(0)
cv2.destroyAllWindows()