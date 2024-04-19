# Google Cloud Storage API Integration with ASP.NET Core

This repository contains a sample ASP.NET Core application demonstrating how to integrate Google Cloud Storage API for file uploads.

## Getting Started

To get started with this project, follow these steps:

1.  **Clone the repository**:

    `git clone https://github.com/kemogu/google-storage-api-.net.git` 
    
2.  **Install the required packages**:
    
    Make sure you have the necessary packages installed. You can restore the packages using NuGet Package Manager:
    
    `dotnet restore` 
    
3.  **Set up Google Cloud Storage credentials**:
    
    In order to use Google Cloud Storage API, you need to set up credentials. Follow the instructions provided by Google to generate a JSON key file.
    
4.  **Update Google Cloud Storage credentials**:
    
    Replace `"your-json-file"` with the path to your JSON key file and `"your-bucket-name"` with the name of your Google Cloud Storage bucket in the HomeController.cs file.
    
5.  **Run the application**:
    
    You can run the application using the following command: 
    
    `dotnet run` 
    
6.  **Access the application**:
    
    Once the application is running, you can access it through your web browser at `http://localhost:5000` or `https://localhost:5001`.
    

## Usage

1.  Navigate to the home page.
2.  Fill in your email address and password.
3.  Choose up to three files to upload (allowed formats: .jpg, .jpeg, .png, .pdf, .doc, .docx, .rtf).
4.  Click the "Submit" button to upload the files to Google Cloud Storage.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.