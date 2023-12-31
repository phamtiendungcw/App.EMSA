import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticateService } from 'src/app/services/authenticate.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  form!: FormGroup;

  constructor(private _userService: UserService, private _authService: AuthenticateService, private _fb: FormBuilder) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.form = this._fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }
  submit(): void {
    if (!this.form.valid) {
      return; // TODO: show msg
    }
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    // TODO: unsubscribe
    this._userService.login(username, password).subscribe({
      next: token => {
        if (token?.length) {
          this._authService.persistToken(token);

          // TODO: use redirectUrl
        }
      },
    });
  }
}
