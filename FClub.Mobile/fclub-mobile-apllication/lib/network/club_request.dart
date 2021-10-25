import 'dart:io';

import 'package:UniClub/main/constants.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/foundation.dart';
import 'package:UniClub/model/club.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class ClubRequest {
  static const String url =
      'https://club-management-service.azurewebsites.net/api/v1/clubs';

  static Future<List<Club>> fetchClubs({int page = 1}) async {
    String token = await FirebaseAuth.instance.currentUser!.getIdToken();
    print(token);
    final response = await http.get(
      Uri.parse(url),
      headers: {HttpHeaders.authorizationHeader: tokenauthor},
    );
    if (response.statusCode == 200) {
      return parseClubs(response.body);
    } else if (response.statusCode == 404) {
      throw Exception("Not found.");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Can't get club");
    }
  }

  static Future<Club> fetchClubsById(String? id) async {
    var queryParameters = {'userId': id};
    var uri = Uri.https('club-management-service.azurewebsites.net',
        '/api/v1/clubs', queryParameters);
    final response = await http.get(
      uri,
      headers: {HttpHeaders.authorizationHeader: tokenauthor},
    );
    if (response.statusCode == 200) {
      return parseClub(response.body);
    } else if (response.statusCode == 404) {
      throw Exception("Not found.");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Can't get club");
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

  static List<Club> parseClubs(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    List<Club> clubs = list.map((model) => Club.fromJson(model)).toList();
    return clubs;
  }

  static Club parseClub(String responseBody) {
    var list = json.decode(responseBody) as List<dynamic>;
    Club club = list.map((model) => Club.fromJson(model)).first;
    return club;
  }
}
