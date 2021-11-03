import 'package:UniClub/model/user.dart';
import 'package:UniClub/network/user_request.dart';
import 'package:rxdart/rxdart.dart';
import '';

class StudentBloc {
  final _studentRequest = UserRequest();
// Tạo sink, cần import: rx dart
  final _studentFetcher = PublishSubject();
// Tạo Stream
  Stream<dynamic> get allStudent => _studentFetcher.stream;

  fetchUserByEmail() async {
    Student? user = await UserRequest.fetchUserByEmail("vhnguyen2k@gmail.com");
    _studentFetcher.sink.add(user);
  }

  dispose() {
    _studentFetcher.close();
  }
}
