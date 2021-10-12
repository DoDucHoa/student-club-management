import 'package:firebase_storage/firebase_storage.dart';
import 'package:flutter/material.dart';

class FireStorageService extends ChangeNotifier {
  FireStorageService();

  Future<String> loadFromStorage(String? image) async {
    String url =
        await FirebaseStorage.instance.refFromURL(image!).getDownloadURL();
    print(url);
    return url;
  }
}
