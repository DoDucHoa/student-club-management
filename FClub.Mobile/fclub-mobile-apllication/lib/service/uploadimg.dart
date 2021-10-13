// import 'dart:io';

// import 'package:flutter/material.dart';

// class UploadService{
//   File? _imageFile;


//   Future uploadImageToFirebase(BuildContext context) async {
//     String fileName = basename(_imageFile?.path);
//     StorageReference firebaseStorageRef =
//         FirebaseStorage.instance.ref().child('uploads/$fileName');
//     StorageUploadTask uploadTask = firebaseStorageRef.putFile(_imageFile);
//     StorageTaskSnapshot taskSnapshot = await uploadTask.onComplete;
//     taskSnapshot.ref.getDownloadURL().then(
//           (value) => print("Done: $value"),
//         );
//   }
// }