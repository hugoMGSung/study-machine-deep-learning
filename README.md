# OpenCV 스터디
OpenCV 클로닝 리포지토리

## 사전 결론
- Python과 C#의 OpenCV 구조가 다름 - 둘다 공부해야 함

## OpenCvSharp (C#) Part

### 기본 사용법

### 기본 데이터타입

#### 구조체 영역
- 벡터 구조체
- 포인트 구조체
- 스칼라 구조체
- 사이즈 구조체
- 범위 구조체
- 직사각형 구조체
- 회전직사각형 구조체

#### Mat 데이터
- Mat 데이터 형식은 **C# OpenCvSharp에서 가장 중요한 데이터 타입**
    - 행렬이나 배열을 저장하기 위한 데이터 타입

- Mat 클래스
    - header와 data pointer로 구성

##### Dense Matrix
- 조밀 행렬 - 의미있는 값으로 구성된 행렬

##### Sparse Matrix
- 희소 행렬 - 대부분의 값이 0인 경우의 행렬

### 이미지변형

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv002.png' width='850'>

#### 색상 배열병합
- 예 - HUE에서 빨간색부분과 파란색부분만 병합해서 표시할 수 있음(생략)

### 이진화

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv004.png' width='850'>

#### 적응형 이진화(AdaptiveThreshold)

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv005.png' width='850'>

### 이미지연산

#### 함수 종류
- 덧셈함수
- 뺄셈함수
- 곱셈함수
- 나눗셈함수
- 최대값함수
- 최소값함수
- 절대값함수
- 절대값차이함수
- 비교함수
- 선형방정식 시스템의 해 찾기함수
- AND 연산함수
- OR 연산함수
- XOR 연산함수
- NOT 연산함수

#### 흐림효과
- 블러링 - 테두리 외삽법
- 단순흐림효과
- 박스필터 흐림효과
- 중간값 흐림효과
- 가우시안 흐림효과
- 양방향 필터흐림효과

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv007.png' width='850'>

### 기타연산 생략

### 이미지 검출
- 가장자리 검출 - 가장 바깥부분의 둘레, 객체의 테두리

#### 소벨 미분
- 영상에서의 미분은 인접한 픽셀들의 차이로 기울기(Gradient)의 크기 도출
- 커널을 사용해 미분하며 커널의 크기를 홀수값을 가짐

    <img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv008.png' width='850'>

#### 샤르 필터
- 소벨 미분의 단점을 보완한 방식. 
- 3x3 필터를 사용

#### 라플라시안
- 2차 미분 형태...

#### 캐니 엣지
- 가장자리를 검출하는 데 목적을 둔 알고리즘

    <img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv009.png' width='850'>

### 윤곽선 검출


    
## OpenCv (Python) Part

### 기본 사용법

### 기본 데이터타입

#### 자료형 영역
- 리스트
- 튜플
- 사전
- 집합

### 이미지변형

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv003.png' width='850'>

### 이진화

#### 적응형 이진화

<img src='https://raw.githubusercontent.com/hugoMGSung/study-opencv/refs/heads/main/images/opencv006.png' width='850'>

