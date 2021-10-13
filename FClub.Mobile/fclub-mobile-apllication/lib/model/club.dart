class Club {
  String? id;
  String? universityId;
  String? name;
  double? balance;
  String? logo;

  Club({this.id, this.universityId, this.name, this.balance, this.logo});

  Club.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    universityId = json['universityId'];
    name = json['name'];
    balance = json['balance'];
    logo = json['logo'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['universityId'] = this.universityId;
    data['name'] = this.name;
    data['balance'] = this.balance;
    data['logo'] = this.logo;
    return data;
  }
}
