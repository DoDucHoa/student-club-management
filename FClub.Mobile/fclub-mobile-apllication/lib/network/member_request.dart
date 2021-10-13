import 'dart:io';

import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_auth/model/club.dart';
import 'package:flutter_auth/model/member.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;

class MemberRequest {
  static const String url =
      'https://club-management-service.azurewebsites.net/api/v1/members';

  static Future<Member> fetchMembers() async {
    final response = await http.get(
      Uri.parse(url),
      headers: {
        HttpHeaders.authorizationHeader:
            'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imhob2EwOTc4QGdtYWlsLmNvbSIsInVuaXF1ZV9uYW1lIjoiSMOyYSIsIm5iZiI6MTYzMzcwNjczNywiZXhwIjoxNjM0MTM4NzM3LCJpYXQiOjE2MzM3MDY3Mzd9.CHfAP6Mix7CBgbGSAHEiwmVMB0t0OiveTzszNUuViMM'
      },
    );
    if (response.statusCode == 200) {
      return parseMember(response.body);
    } else if (response.statusCode == 404) {
      throw Exception("Not found.");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Can't members");
    }
  }

  static Future<Member>? fetchMembersById(int? id) async {
    var queryParameters = {
      'userId': id.toString(),
      'includeProperties': 'Club'
    };
    var uri = Uri.https('club-management-service.azurewebsites.net',
        '/api/v1/members', queryParameters);
    final response = await http.get(
      uri,
      headers: {
        HttpHeaders.authorizationHeader:
            'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imhob2EwOTc4QGdtYWlsLmNvbSIsInVuaXF1ZV9uYW1lIjoiSMOyYSIsIm5iZiI6MTYzMzcwNjczNywiZXhwIjoxNjM0MTM4NzM3LCJpYXQiOjE2MzM3MDY3Mzd9.CHfAP6Mix7CBgbGSAHEiwmVMB0t0OiveTzszNUuViMM'
      },
    );
    if (response.statusCode == 200) {
      return parseMember(response.body);
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

  static Member parseMember(String responseBody) {
    var jsonResponse = json.decode(responseBody);
    Member member = Member.fromJson(jsonResponse);
    return member;
  }
}
