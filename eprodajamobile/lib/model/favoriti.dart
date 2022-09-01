import 'dart:convert';

class Favoriti {
  final int favoritiId;
  final String imePrezimeKorisnika;
  final String datumOznacavanja;

  Favoriti(
      {required this.favoritiId,
      required this.imePrezimeKorisnika,
      required this.datumOznacavanja});

  factory Favoriti.fromJson(Map<String, dynamic> json) {
    return Favoriti(
      favoritiId: json["favoritiId"],
      imePrezimeKorisnika: json["imePrezimeKorisnika"],
      datumOznacavanja: json["datumOznacavanja"],
    );
  }
}
