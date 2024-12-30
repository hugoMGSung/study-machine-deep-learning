# hungout-with-yolo
YOLO 가지고 놀기

## Line detection Clonning practice


## Raspberry Pi 5 Yolo8 Test
### 라이브러리 인스톨

```shell
$ pip install ultralytics
```

### 이미지 테스트
```shell
$ yolo predict model=yolov8n.pt source='https://ultralytics.com/images/bus.jpg'
```

- 결과
	
	<img src="https://raw.githubusercontent.com/hugoMGSung/hungout-with-yolo/main/images/yolo001.jpg" width="450">


### 동영상 테스트
```shell
$ yolo predict model=yolov8n.pt source=/home/pi/Videos/sample.mp4 show=True
```

- 결과

	<img src="https://raw.githubusercontent.com/hugoMGSung/hungout-with-yolo/main/images/yolo002.png" width="700">