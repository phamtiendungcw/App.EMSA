import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { PingService } from 'src/app/services/ping.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  constructor(private _pingService: PingService) {}

  ngOnInit(): void {
    this._pingService
      .ping()
      .pipe(take(1))
      .subscribe({ next: ping => console.log('Ping authenticated: ' + ping) });
    this._pingService
      .pingAnonymous()
      .pipe(take(1))
      .subscribe({ next: ping => console.log('Ping anonymous: ' + ping) });
  }
}
