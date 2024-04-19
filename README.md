This file shows the program workflow. (Indev!)

Let's begin. The encryption method using Polybius square was invented back in Greece in the 2nd century BC. It's a table of the letters of the English alphabet. Each letter has its own number. It is determined by which row and column the letter is in. <br />
<p align="center">
  <img src="https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/PolibiusSquare.png" width="200"/>
</p>

For example, we need to encrypt the letter Y. To do this, we find the letter Y in the table and look at the number in which column and row the letter is located. For Y it is row 5, column 4, i.e. the encrypted letter Y will be labeled as 54 <br />
<p align="center">
  Let's proceed to the program description <br />
</p>
<p align="center" fontsize="14">
  <img src="https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/MainPage.png"/> <br />
</p>

Main window. In it you can see the following components. The field for entering text for encryption-decryption is a "TextBox" component. The output field of the encrypted - decrypted text below is also a "TextBox" component, only with the IsReadOnly = true parameter. Console of the output of actions performed by the program, also being a component "TextBox" only with the parameter IsReadOnly = true. Buttons ENCRYPT and DECRYPT, which perform the function of selecting the method with which the program works. Buttons INFO in the upper right part of the window, about it later. And buttons to start method execution. <br />

Let's just encrypt something! <br />
In the text field, write "Monkey loves babana" and start the encryption operation. <br />

![EncryptOperation](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/EncryptOperation.png) <br />

Once executed, you can see the actions performed by the program to encrypt the text in the console, as well as the encrypted text itself in the box below. <br />

![DecryptOperation](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/DecryptOperation.png) <br />

![PostCodes](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/PostCodes.png) <br />

![EncryptorInterrupted](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/EncryptorInterrupted.png) <br />

![DecryptorInterrupted](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/DecryptorInterrupted.png) <br />

![OperationInterrupted](https://github.com/Shuupa/Encryptor-polybius-square-byShuupa/blob/master/Screen/OperationInterrupted.png) <br />
