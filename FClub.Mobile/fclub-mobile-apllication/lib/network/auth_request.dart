import 'dart:io';

import 'package:flutter/foundation.dart';
import 'package:UniClub/model/club.dart';
import 'package:UniClub/model/token.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class AuthRequest {
  Future signIn(String? tokenId) async {
    var queryParameters = {'IdToken': tokenId};
    var uri = Uri.https('club-management-service.azurewebsites.net',
        '/api/v1/auths/sign-in', queryParameters);
    print("ggid: ${tokenId}");
    final response = await http.post(uri);
    if (response.statusCode == 200) {
      print('sign in succesful!');
    } else if (response.statusCode == 404) {
      throw Exception("Not found.");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Can't sign in");
    }
  }

  Future signUp(String? tokenId, String university, String username) async {
    var queryParameters = {
      'IdToken': tokenId,
      'universityId': university,
      'username': username
    };
    var uri = Uri.https('club-management-service.azurewebsites.net',
        '/api/v1/auths/sign-up', queryParameters);
    final response = await http.post(uri);
    if (response.statusCode == 200) {
      print('sign in succesful!');
    } else if (response.statusCode == 404) {
      throw Exception("Not found.");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Can't sign in");
    }
  }
  // static Future<List<Post>> fetchClubs() async {
  //   var parsed = Uri.parse("https://jsonplaceholder.typicode.com/posts");
  //   final response = await http.get(parsed);

  //   if (response.statusCode == 200) {
  //     // If the server did return a 200 OK response,
  //     // then parse the JSON.
  //     return compute(parseClub, response.body);
  //   } else {
  //     // If the server did not return a 200 OK response,
  //     // then throw an exception.
  //     throw Exception('Failed to load album');
  //   }
  // }

  static List<Club> parseClub(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<Club> clubs = list.map((model) => Club.fromJson(model)).toList();
    return clubs;
  }
}
