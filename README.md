# Machine Learning & Deep Learning All Study

## OpenCV(C#)
- [C# OpenCV Basic](https://github.com/hugoMGSung/study-machine-deep-learning/tree/main/cs)

## OpenCV(Python)
- [Python OpenCV Basic](https://github.com/hugoMGSung/study-machine-deep-learning/tree/main/python_opencv)

## Object Detection
- [Object Detection](https://github.com/hugoMGSung/study-machine-deep-learning/tree/main/object-detection)

## Tensorflow Basic
- [Tensorflow](https://github.com/hugoMGSung/study-machine-deep-learning/tree/main/tensorflow) 



## Tensorflow/Keras GPU 설치

### 아나콘다 설치
### Anaconda Prompt 열기
- 아래의 명령어 실행

    ```shell
    (base)...> conda create -n gpu_env python=3.11 -y
    Channels:
    - defaults
    Platform: win-64
    Collecting package metadata (repodata.json): done
    Solving environment: done

    ## Package Plan ##

    environment location: C:\Users\perso\.conda\envs\gpu_env

    added / updated specs:
        - python=3.11
    ```

- 위치 확인 : C:\Users\perso\.conda\envs\gpu_env

- conda 명령어로 가상환경 실행
    ```shell
    (base) C:\Users\perso>conda activate gpu_env

    (gpu_env) C:\Users\perso>
    ```

### Tensorflow 설치
- pip 명령어 입력. Tensorflow 2.1 이상 GPU 자동지원

    ```shell
    (gpu_env) > pip install tensorflow
    ```

- 실행결과. GPU 안됨!! ㅋㅋ

    ```shell
    (gpu_env) C:\Users\perso>python
    Python 3.11.11 | packaged by Anaconda, Inc. | (main, Dec 11 2024, 16:34:19) [MSC v.1929 64 bit (AMD64)] on win32
    Type "help", "copyright", "credits" or "license" for more information.
    >>> import tensorflow as tf
    2025-04-18 16:14:38.033392: I tensorflow/core/util/port.cc:153] oneDNN custom operations are on. You may see slightly different numerical results due to floating-point round-off errors from different computation orders. To turn them off, set the environment variable `TF_ENABLE_ONEDNN_OPTS=0`.
    2025-04-18 16:14:43.253354: I tensorflow/core/util/port.cc:153] oneDNN custom operations are on. You may see slightly different numerical results due to floating-point round-off errors from different computation orders. To turn them off, set the environment variable `TF_ENABLE_ONEDNN_OPTS=0`.
    >>> tf.__version__
    '2.19.0'
    >>> tf.config.list_physical_devices('GPU')
    []
    >>> tf.config.list_physical_devices('CPU')
    [PhysicalDevice(name='/physical_device:CPU:0', device_type='CPU')]
    >>>
    ```