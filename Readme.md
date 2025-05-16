# Meeting Scheduler

Frontendová část aplikace MeetingScheduler, vytvořená v rámci semestrální práce. Uživatelské rozhraní je napsáno v jazyce C# pomocí technologie WPF.

## Application run
Release verze aplikace se nachází ve složce: ..\ms\bin\Release\net8.0-windows soubor ms.exe.

Aplikace má serverovou část, která má omezení od hostingu. Hosting je zdarma, proto pokud nikdo neposílá na server požadavky, server se vypíná. Aby se rozjel, je potřeba poslat požadavek. První požadavek na server (přihlášení nebo registrace) bude trvat kolem 2 minut a může se stát, že program skončí vyhozením výjimky TaskCanceledException. Bohužel nejsem si jistá, jak to opravit; je to způsobeno tím, že server dlouho neodpovídá, protože startuje. 
Za 2-3 minuty server se rozjede a bude dostupný, pokud budou přicházet nové požadavky. Pokud není žádný požadavek během 15+ minut, server se vypíná.

Pro použití aplikace je nutné se přihlásit do systému:
a) buď se zaregistrovat, přičemž e-mail, který systém vyžaduje, nemusí opravdu existovat; žádné zprávy systém při registraci neposílá
b) přihlásit se do existujícího účtu. Mám několik vytvořených účtů pro účely testování, pokud budete potřebovat, přihlašovací údaje jsou:
1.username: ```janedoe```
password: ```test```

2.username ```test```
password: ```pass111```

Pro vyzkoušení všech funkcí aplikace je nutné vidět alespoň 2 účty, protože funkce hosta je dostupná pouze tehdy, když vlastník události A přihlásí uživatele B jako hosta k události.

Pokud z nějakého důvodu kód ze zip archivu nejde spustit, přidávám veřejnou kopii kódu na školní GitLab: ```https://gitlab.fel.cvut.cz/kyryliry/ms```
