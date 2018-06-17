import { Component, OnInit } from '@angular/core';
import {Item} from '../../models/item';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {

  items : Item[] = [
    new Item("AK-47", "https://images6.alphacoders.com/412/thumb-1920-412813.jpg"),
    new Item("AR-15", "https://stmed.net/sites/default/files/colt-ar-15-wallpapers-29037-5030544.jpg"),
    new Item("M16A4", "https://images5.alphacoders.com/283/283267.jpg"),
    new Item("Galil ACE", "https://i.ytimg.com/vi/qN4FJy2Dh3E/maxresdefault.jpg"),
    new Item("FN SCAR", "https://images6.alphacoders.com/673/673068.png"),
    new Item("G36", "https://img00.deviantart.net/b6cb/i/2013/088/9/6/tac_g36_airsoft_by_weiserhei-d2ivyjj.jpg"),
  ];

  constructor() { }

  ngOnInit() {
  }

}
