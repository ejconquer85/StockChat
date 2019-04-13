import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private hubConnection: HubConnection;
  public userName = '';
  message = '';
  private  messages: string[] = [];

  ngOnInit() {
    this.userName = window.prompt('Your name:', 'John');

    let hubConnectionBuilder = new HubConnectionBuilder();

    this.hubConnection = hubConnectionBuilder.withUrl('http://localhost:5005/signalr').build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this.hubConnection.on('send', (userName: string, message: string) => {
      const text = userName + ': ' + message;
      this.messages.push(text);
    });

  }

  public sendMessage(): void {
    this.hubConnection
      .invoke('send', this.userName, this.message)
      .catch(err => console.error(err));
  }
}
