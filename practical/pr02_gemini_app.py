import tkinter as tk
from tkinter import scrolledtext
import google.generativeai as genai
## pip install google-generativeai
## https://aistudio.google.com/apikey?hl=ko


# 생성 AI 구성
genai.configure(api_key='YourKey') # API 키로 AI 모델을 구성
model = genai.GenerativeModel('gemini-1.5-flash')   # 사용할 AI 모델 지정

# 봇의 사용자 맞춤형 소개 메시지 정의
intro_prompt = (
    '저는 유고봇입니다. 여러분의 질문에 답하고 다양한 작업을 돕기 위해 설계된 여러분이 조수입니다.'
    '필요한 모든 것을 도와드릴 수 있습니다. 그냥 물어보세요!!'
)

# 응답을 생성하는 함수 정의
def generate_response():
    user_text = user_input.get('1.0', tk.END).strip()  # 사용자가 입력한 텍스트 가져오기
    if user_text:  # 사용자가 텍스트를 입력한 경우
        try:
            # 사용자의 메시지를 채팅 패널에 표시
            chat_panel.insert(tk.END, '당신: ', 'bold')  # 'You: ' 텍스트를 굵게
            chat_panel.insert(tk.END, f'{user_text}\n', 'user')   # 사용자의 메시지 텍스트 표시

            # 사용자 입력과 봇의 소개 메시지를 결합
            full_prompt = f'{intro_prompt}\n\n사용자: {user_text}\n유고봇:'

            # AI 응답 생성
            ai_response = model.generate_content(full_prompt)
            response = ai_response.text  # 생성된 응답 텍스트 추출

            # 응답에 원하지 않는 AI 관련 내용이 포함된 경우, 맞춤형 소개로 대체
            if 'large language model' in response or 'Google AI' in response:
                response = intro_prompt  # 소개 메시지로 대체

            # AI의 응답을 채팅 패널에 표시
            chat_panel.insert(tk.END, '유고봇: ', 'bold')  # '유고봇: ' 텍스트를 굵게
            chat_panel.insert(tk.END, f'{response}\n', 'ai')  # AI 응답 텍스트 표시

            # 채팅 패널을 아래로 스크롤
            chat_panel.see(tk.END)

            # 입력 박스 초기화
            user_input.delete('1.0', tk.END)
        except Exception as e:
            # 오류 발생 시 오류 메시지 표시
            chat_panel.insert(tk.END, f'Error: {str(e)}\n', 'error')

def key(event):
    # print(repr(event.char))
    if event.char == '\r':
        generate_response()
        user_input.delete('1.0', tk.END)

# 메인 윈도우 생성
root = tk.Tk()
root.title('재미니 채팅앱')  # 창 제목 설정
root.geometry('800x600')  # 창 크기 설정

# 채팅 패널 (스크롤 가능)
chat_panel = scrolledtext.ScrolledText(root, wrap=tk.WORD, font=('NanumGothic', 10), bg='white', fg='black')
chat_panel.pack(padx=10, pady=10, fill=tk.BOTH, expand=True)  # 채팅 패널을 윈도우에 배치

# 사용자와 AI 메시지를 위한 태그 설정
chat_panel.tag_configure('user', font=('NanumGothic', 10, 'bold'), foreground='black')  # 사용자 메시지   
chat_panel.tag_configure('ai', font=('NanumGothic', 10), foreground='black') # AI 메시지
chat_panel.tag_configure('bold', font=('NanumGothic', 10, 'bold'))  # 굵은 텍스트
chat_panel.tag_configure('error', font=('NanumGothic', 10, 'italic'), foreground='red') # 오류 메시지

# 입력 프레임 (사용자 입력을 위한 프레임)
input_frame = tk.Frame(root, bg='#f5f5f5')
input_frame.pack(fill=tk.X, padx=10, pady=5) # 입력 프레임을 윈도우에 배치

# 사용자 입력 박스
user_input = tk.Text(input_frame, height=2, font=('NanumGothic', 10), wrap=tk.WORD)
user_input.bind('<Key>', key)
user_input.pack(side=tk.LEFT, padx=5, pady=5, fill=tk.X, expand=True)  # 입력 박스를 왼쪽에 배치

# 전송 버튼
send_button = tk.Button(input_frame, text='전송', command=generate_response, font=('NanumGothic', 10), bg='black', fg='white')
send_button.pack(side=tk.RIGHT, padx=5, pady=5)   # 전송 버튼을 오른쪽에 배치

user_input.focus_set()

# GUI 애플리케이션 실행(무한루프)
root.mainloop()