import 'member.dart';

class Wallet {
  List<Data>? data;
  Metadata? metadata;

  Wallet({this.data, this.metadata});

  Wallet.fromJson(Map<String, dynamic> json) {
    if (json['data'] != null) {
      data = <Data>[];
      json['data'].forEach((v) {
        data?.add(new Data.fromJson(v));
      });
    }
    metadata = json['metadata'] != null
        ? new Metadata.fromJson(json['metadata'])
        : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    if (this.data != null) {
      data['data'] = this.data?.map((v) => v.toJson()).toList();
    }
    if (this.metadata != null) {
      data['metadata'] = this.metadata?.toJson();
    }
    return data;
  }
}

class Data {
  int? id;
  int? memberId;
  double? point;
  Member? member;

  Data({this.id, this.memberId, this.point, this.member});

  Data.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    memberId = json['memberId'];
    point = json['point'];
    member =
        json['member'] != null ? new Member.fromJson(json['member']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['memberId'] = this.memberId;
    data['point'] = this.point;
    if (this.member != null) {
      data['member'] = this.member?.toJson();
    }
    return data;
  }
}

class Metadata {
  int? totalCount;
  int? pageSize;
  int? currentPage;
  int? totalPages;
  bool? hasNext;
  bool? hasPrevious;

  Metadata(
      {this.totalCount,
      this.pageSize,
      this.currentPage,
      this.totalPages,
      this.hasNext,
      this.hasPrevious});

  Metadata.fromJson(Map<String, dynamic> json) {
    totalCount = json['totalCount'];
    pageSize = json['pageSize'];
    currentPage = json['currentPage'];
    totalPages = json['totalPages'];
    hasNext = json['hasNext'];
    hasPrevious = json['hasPrevious'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['totalCount'] = this.totalCount;
    data['pageSize'] = this.pageSize;
    data['currentPage'] = this.currentPage;
    data['totalPages'] = this.totalPages;
    data['hasNext'] = this.hasNext;
    data['hasPrevious'] = this.hasPrevious;
    return data;
  }
}
