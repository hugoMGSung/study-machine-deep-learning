import tkinter as tk
from tkinter import scrolledtext
import google.generativeai as genai

# Configure the generative AI
genai.configure(api_key="your_key")
model = genai.GenerativeModel("gemini-1.5-flash")

# Define a custom introduction for the bot
intro_prompt = (
    "I am MuskanBot, your helpful assistant, designed to answer your questions "
    "and assist with various tasks! I can help with anything you need. Just ask!"
)

# Function to generate a response

def generate_response():
    user_text = user_input.get("1.0", tk.END).strip()
    if user_text:
        try:
            # Display the user's message in the chat panel
            chat_panel.insert(tk.END, "You: ", "bold")
            chat_panel.insert(tk.END, f"{user_text}\n", "user")

            # Combine the user input with the introduction
            full_prompt = f"{intro_prompt}\n\nUser: {user_text}\nMuskanBot:"

            # Generate AI response
            ai_response = model.generate_content(full_prompt)
            response = ai_response.text  # Get the generated response text

            # Check if the response contains any unwanted AI-specific content
            if "large language model" in response or "Google AI" in response:
                response = intro_prompt  # Replace with the custom introduction

            # Display the AI's response in the chat panel
            chat_panel.insert(tk.END, "MuskanBot: ", "bold")
            chat_panel.insert(tk.END, f"{response}\n", "ai")

            # Scroll to the bottom
            chat_panel.see(tk.END)

            # Clear the input box
            user_input.delete("1.0", tk.END)
        except Exception as e:
            chat_panel.insert(tk.END, f"Error: {str(e)}\n", "error")

# Create the main window
root = tk.Tk()
root.title("Simple Chatbot Interface")
root.geometry("800x600")

# Chat panel (scrollable)
chat_panel = scrolledtext.ScrolledText(root, wrap=tk.WORD, font=("Arial", 12), bg="white", fg="black")
chat_panel.pack(padx=10, pady=10, fill=tk.BOTH, expand=True)

# Configure tags for user and AI messages
chat_panel.tag_configure("user", font=("Arial", 12, "bold"), foreground="black")
chat_panel.tag_configure("ai", font=("Arial", 12), foreground="black")
chat_panel.tag_configure("bold", font=("Arial", 12, "bold"))
chat_panel.tag_configure("error", font=("Arial", 12, "italic"), foreground="red")

# Input frame (for user input)
input_frame = tk.Frame(root, bg="#f5f5f5")
input_frame.pack(fill=tk.X, padx=10, pady=5)

# User input box
user_input = tk.Text(input_frame, height=2, font=("Arial", 12), wrap=tk.WORD)
user_input.pack(side=tk.LEFT, padx=5, pady=5, fill=tk.X, expand=True)

# Send button
send_button = tk.Button(input_frame, text="Send", command=generate_response, font=("Arial", 12), bg="black", fg="white")
send_button.pack(side=tk.RIGHT, padx=5, pady=5)

# Run the main loop
root.mainloop()