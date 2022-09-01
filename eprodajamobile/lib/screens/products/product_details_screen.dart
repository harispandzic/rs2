import 'package:eprodajamobile/providers/favoriti_providet.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import '../../model/favoriti.dart';
import '../../model/product.dart';
import '../../providers/product_provider.dart';
import '../../utils/util.dart';
import '../../widgets/master_screen.dart';

import 'package:eprodajamobile/providers/product_provider.dart';
import 'package:eprodajamobile/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ProductDetailsScreen extends StatefulWidget {
  static const String routeName = "/product_details";
  String id;
  ProductDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  ProductProvider? _productProvider = null;
  FavoritiProvider? _favoritiProvider = null;
  Product? data;
  List<Favoriti> favoriti = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _favoritiProvider = context.read<FavoritiProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _productProvider?.getById(int.parse(widget.id));
    var tmpData1 =
        await _favoritiProvider?.get({"proizvodId": int.parse(widget.id)});
    print(tmpData);
    setState(() {
      data = tmpData!;
      favoriti = tmpData1!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(
          child: ListView(
        shrinkWrap: true,
        scrollDirection: Axis.vertical,
        children: [
          Container(
            child: imageFromBase64String(data?.slika! ?? ""),
          ),
          Text(data?.naziv ?? ""),
          Text(data?.cijena.toString() ?? ""),
          IconButton(
            icon: Icon(Icons.favorite),
            onPressed: () async {
              Map data = {
                'proizvodId': int.parse(widget.id),
                'username': Authorization.username,
              };
              var tmpData = await _favoritiProvider?.insert(data);
              var tmpData1 = await _favoritiProvider
                  ?.get({"proizvodId": int.parse(widget.id)});
              print(tmpData);
              setState(() {
                favoriti = tmpData1!;
              });
              print(tmpData);
            },
          ),
          ListView(
              shrinkWrap: true,
              scrollDirection: Axis.vertical,
              children: _buildProductCardList())
        ],
      )),
    );
  }

  List<Widget> _buildProductCardList() {
    if (favoriti.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = favoriti
        .map((x) => Container(
              child:
                  Text(x.imePrezimeKorisnika + " " + x.datumOznacavanja ?? ""),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
