# תיכנון רכיבים דינאמיים

## מאפיינים
1) המאפיינים העיקריים של העצמיים במשחק שלנו הם מהירות וגובה הקפיצה של השחקנים שכרגע עומדים על ריצה קלה.
* מהירות הריצה הקלה עומדת על 5f וריצה מהירה במהירות של 7f כרגע זה נראה כמו התחלה טובה למרות שכרגע הילדים היריבים מסתובבים ברדיוס אז אין כל כך בריחה לכן זה טוב הילדים פשוט מפוזרים במפה במרחק מספיק רחוק שיקח לשחקן זמן להגיע.

## מיקומים
2) המיקומים של החפציים העיקרים במשחק שלנו הם המתקני גן שעשועים שמפוזרים באופן שווה על מנת ליצור מכשולים לשחקן ואופציה לילדים היריבים שלו "לברוח" או "להתחבא" מפני השחקן שלא יתפוס אותם.
אותם ילדים יריבים ממוקמים במקומות רנדומליים במשחק ומרגע ההתחלה של המשחק אותם ילדים ילכו רנדומלית לפי רדיוס של עצם שנקבע להם במידה וזה עץ או עצם במגרש משחקים או השחקן עצמו במטרה לברוח ממנו.
* קבענו את המיקום לפי סידור סטנדרטי של גן שעשועים שהיה לכולנו ליד הבית שהיינו קטנים והולכים לשחק שם תופסת עם חברים שלנו על מנת לדמות את מה שהיה לנו כשגדלנו ובכך יש מספיק מכשולים ומקומות לברוח אליהם.

## התנהגויות
3) ההתנהגויות העיקריות של העצמים במשחק שלנו הן תנועה וקפיצה, הילדים שצריך לתפוס מסתובבים סביב עצם מסוים ברדיוס של 20.5f ברנדומליות והשחקן הראשי רץ לפי שליטה של השחקן על ידי wasd או החצים ושולט על הנקודת מבט שלו עם המצלמה שהשחקן זז לפי לאן המצלמה מסתכלת.
* התופעות המורכבות שנוצרות בעולם של המשחק כתוצאה מכללי ההתנהגות של עצמים שונים היא שלפעמיים הילדים שזזים רנדומלית נתקעים באיזה שהוא עצם אחר או אותו עצם שהם אמורים להסתובב סביבו ופשוט נתקעים במצב שהם זזים לכיוונו אבל הם בעצם תקועים בתוכו.

## כלכלה
4) מבחינת כלכלה כרגע אין לנו מערכת כלכלית במשחק אך ניתן להתאים מערכת כזאת על מנת לקנות דמויות שונות שיכולות לשמש בתור השחקן הראשי ולהם לתת מאפיינים שונים של מהירות וגובה קפיצה וניתן גם לממש דמויות מיוחדות שניתן לרכוש בכסף אמיתי שקונים מחוץ למשחק ואז מקבלים יתרון יותר גדול.

## מידע
5) המידע שזמין לשחקן בכל רגע נתון הוא כמה ילדים נשאר לתפוס, מה הזמן הנותר לשלב הנוכחי ובאיזה שלב השחקן נמצא כרגע וכל זה מוצג לו בUI על המסך ככה שיוכל לעקוב אחרי כמה זמן נשאר וכמה ילדים נשאר לתפוס על מנת לעבור את השלב.
* במשחק שלנו בחרנו בנוקדת מבט מגוף שלישי כי חשבנו שזה יהיה יותר נוח לשחקן לראות לאן רצים כל הילדים ובגלל שככל שהשחקן מתקדם ברמות ככה יש יותר ויותר ילדים רצוי שיהיה זווית ראייה כמה שיותר רחבה על מנת שיוכל לראות ולדעת איפה נמצאים הילדים האחרים מכיוון שאין שום עזר שאומר איפה הילדים נמצאים על מנת להקשות על המשחק חוץ מעזר שאומר כמה נשאר לתפוס.

## שליטה
6) שיטת השליטה של השחקן על מצב המשחק היא שליטה ישירה בזמן אמת מכיוון שהשחקן נמצא תחת לחץ של זמן שחושב במיוחד שכל עוד השחקן נמצא תמיד במצב של תנועה לעבר הילדים הנותרים הוא אמור להספיק.
אם השחקן נתקע במכשול או נפל, אז נגמר הזמן ומתחיל השלב מחדש, מה שיוצר ריכוז כי העונש על חוסר ריכוז וחישוב לאן צריך לרוץ הוא כבד (התחלת כל השלב מההתחלה) במיוחד שיש מסלול לפלטפורמות שונות וניתן בטעות קטנה ליפול סתם ככה לכן רצוי לנצל כל שנייה שיש על מנת לוודא שהשחקן לא יפול סתם ככה.

## בחירות
7) הבחירות שהשחקנים שלנו יצטרכו לבצע תוך כדי המשחק הם למי לרוץ לתפוס קודם ואיך לבצע את הקפיצה המושלמת בין פלטפורמה לפלטפורמה כי כל סטייה קטנה תגרום לנפילה, פסילה והתחלה מחדש של השלב לכן רצוי להשקיע בכך מחשבה וגם תרגול כנראה שהשחקן יפול הרבה פעמיים עד שיצליח לבצע את הקפיצה באופן מושלם.
