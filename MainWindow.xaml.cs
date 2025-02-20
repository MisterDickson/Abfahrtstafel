using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.


namespace Abfahrtstafel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        List<(string name, string acronym)> alleStationen = new List<(string name, string acronym)>
{
("Abfaltersbach", "Abf%20H1"),
("Abschlag", "Sgp%20H1"),
("Absdorf-Hippersdorf", "Ah"),
("Achau", "Ach"),
("Achenlohe", "Nst%20H4H"),
("Achleitnersiedlung", "Puw%20H1A"),
("Admont", "Ad"),
("Aggsbach Markt", "A"),
("Aich im Jauntal", "Spa%20H3"),
("Aich-Assach", "Grb%20H2"),
("Aigen-Schl�gl", "Ai"),
("Aisthofen", "P%20H1"),
("Allentsteig", "All"),
("Allerheiligen-M�rzhofen", "Ki%20H1"),
("Allerheiligenh�fe", "Ih%20H1"),
("Alling-Tobisegg", "Lnn%20H1"),
("Altach", "Got%20H1"),
("Altenhof", "Plk%20H1"),
("Altenmarkt im Pongau", "Rad%20K1"),
("Altenstadt", "Fk%20H1N"),
("Altm�nster am Traunsee", "Er"),
("Altnagelberg", "Alt"),
("Amstetten", "Ams"),
("Andorf", "Af"),
("Angern", "Ag"),
("Angertal", "Al"),
("Annenheim", "Saf%20H1"),
("Ansfelden", "T%20H1"),
("Antiesenhofen", "Ant"),
("Arbing", "Arb"),
("Ardning", "Ar"),
("Arnoldstein", "Dr"),
("Aschbach", "Ams%20H2"),
("Aspang", "Ap"),
("Asten-Fisching", "Ens%20H1"),
("Attnang-Puchheim", "At"),
("Atzenbrugg", "Tfd%20H2"),
("Aurachkirchen", "Ak"),
("Aurolzm�nster", "Rd%20H2M"),
("Ausschlag-Z�bern", "Auz"),
("Bad Aussee", "Au"),
("Bad Blumau", "Seb%20H3"),
("Bad Deutsch Altenburg", "Bde"),
("Baden", "Bf%20H1"),
("Bad Erlach", "Ela"),
("Bad Fischau", "Fwa%20H1"),
("Bad Fischau-Brunn", "Fib"),
("Bad Gastein", "Bag"),
("Bad Gleichenberg", "Gbg"),
("Bad Goisern", "Stg%20H1"),
("Bad Hofgastein", "Hg"),
("Bad Ischl", "Il"),
("Bad Mitterndorf", "Bam"),
("Bad Mitterndorf-Heilbrunn", "Bam%20H1"),
("Bad Neusiedl am See", "Bns"),
("Bad Radkersburg", "Ra"),
("Bad Ried", "Rd%20H1M"),
("Bad Sauerbrunn", "Sau"),
("Bad Schallerbach-Wallern", "Wa"),
("Bad Vigaun", "Hl%20H2A"),
("Bad V�slau", "Bvs"),
("Bad Waltersdorf", "Seb%20H1"),
("B�rnbach", "Bba"),
("Baumgartenberg", "Bb"),
("Baumgarten-Schattendorf", "Bgt"),
("Baumgartner", "Bau"),
("Bergern", "Otg%20H1"),
("Berg im Drautal", "De%20H1"),
("Berndorf Fabrik", "Tf"),
("Berndorf Stadt", "Tf%20H1"),
("Bernhardsthal", "Beh"),
("Bichlbach Almkopfbahn", "Bch%20H1H"),
("Bichlbach-Berwang", "Bch"),
("Bierbaum", "Bib"),
("Bisamberg", "F%20H3S"),
("Bischofshofen", "Bo"),
("Bleiburg", "Ble"),
("Bleiburg Stadt", "Spa%20K1"),
("Blindenmarkt", "Kar%20H2"),
("Bludenz", "B"),
("Bludenz-Moos", "B%20H1M"),
("B�ckstein", "Bs"),
("Boding", "Frf%20H1"),
("B�heimkirchen", "Bh"),
("B�hlerwerk a.d. Ybbs", "Hk%20H3"),
("Bramberg", "Bgb"),
("Braunau am Inn", "Bru"),
("Bregenz", "Bg"),
("Bregenz Hafen", "Bg%20H1"),
("Breitenbrunn", "Pur%20H1H"),
("Breiteneich bei Horn", "Sh%20H1H"),
("Breitensch�tzing", "Bre"),
("Breitensee N�", "Sfl%20H1"),
("Breitenstein", "Bt"),
("Breitenwaida", "Gr%20H1"),
("Breitwiesen", "Had%20H1"),
("Brixen im Thale", "Kit%20H1"),
("Brixlegg", "Bri"),
("Bruck a.d. Leitha", "Bl"),
("Bruck a.d. Mur", "Bm"),
("Bruckberg", "Tih%20H2"),
("Bruckberg Golfplatz", "Gol"),
("Bruck-Fusch", "Brf"),
("Brunn a.d. Pitten", "Ela%20H1"),
("Brunn a.d. Schneebergbahn", "Fib%20H1"),
("Brunnenfeld-Stahlehr", "B%20H2M"),
("Brunn-Maria Enzersdorf", "Bu"),
("Buchberg", "Gas%20H1"),
("Burk", "Slf%20H2"),
("Dechantskirchen", "Fd%20H1H"),
("Dellach im Drautal", "De"),
("Dellach im Gailtal", "Dgt"),
("Deutschkreutz", "Dk"),
("Deutschlandsberg", "Dlb"),
("Deutsch Wagram", "Wg"),
("Diensthubersiedlung", "Voi%20H3"),
("Dietrichshofen", "Ant%20H1"),
("D�lsach", "Doe"),
("Donnerskirchen", "Sag%20H2"),
("Dorf a.d. Enns", "Ern%20H1"),
("Dorfgastein", "Dg"),
("Dornach", "Gbk%20H1"),
("Dornbirn", "Do"),
("Dornbirn-Schoren", "Hos%20H2"),
("Dra�burg", "Wul%20H1"),
("Dreistetten", "Pie%20H1"),
("Dr�sing", "Drg"),
("D�rnbach", "Lf%20H1"),
("D�rnberg", "Puw%20H1"),
("D�rnkrut", "Due"),
("D�rrwien", "Pm%20H2"),
("Ebenfurth", "Ef"),
("Eben im Pongau", "Ebn"),
("Ebensee", "En"),
("Ebensee Landungsplatz", "En%20H1"),
("Eberschwang", "Ew"),
("Ebreichsdorf", "Ebr"),
("Edlitz-Grimmenstein", "Edl"),
("Eferding", "Efd"),
("Eggenburg", "Egg"),
("Ehrenhausen", "Rzn%20H1"),
("Ehrwald Zugspitzbahn", "Eh"),
("Eichberg", "Eib"),
("Eichgraben-Altlengbach", "Rw%20H1"),
("Eisenstadt", "E"),
("Eisenstadt Schule", "Esu"),
("Eis-Ruden", "Es"),
("Elsbethen", "Aj%20H2"),
("Emmersdorf a.d. Donau", "Emd"),
("Emmersdorf im Gailtal", "Noe%20H1"),
("Enns", "Ens"),
("Ennsdorf", "Sv%20H1"),
("Enzersdorf bei Staatz", "Enz"),
("Enzesfeld-Lindabrunn", "Ez"),
("Erlauf", "Erf"),
("Erlaufklause", "Gng%20H2"),
("Ernstbrunn", "Erb"),
("Ernsthofen", "Ern"),
("Eschenau", "Ld%20H1"),
("Etsdorf-Stra�", "Edo"),
("Eugendorf", "See%20H1"),
("Faak am See", "Fas"),
("Fehring", "Feg"),
("Feldbach", "Fb"),
("Feldbach Landesbahn", "Flb"),
("Feldkirch", "Fk"),
("Feldkirch Amberg", "Fk%20H1"),
("Feldkirchen in K�rnten", "Fel"),
("Feldkirchen-Seiersberg", "Pu%20H1A"),
("Felixdorf", "Fld"),
("Fels", "Fs"),
("Fentsch-St. Lorenzen", "Fes"),
("Ferndorf", "Ro%20H1"),
("Feuerwerksanstalt", "Fwa"),
("Fieberbrunn", "Fie"),
("Finkenstein", "Vo%20H1"),
("Finklham", "Had%20H2"),
("Fischamend", "Fam"),
("Flaurling", "Zl%20K1"),
("Flughafen Graz-Feldkirchen", "Pu%20H1"),
("Flughafen Wien (VIE)", "Fws"),
("F�derlach", "Foe"),
("Frankenfels", "Frf"),
("Frankenmarkt", "Fm"),
("Frastanz", "Fa"),
("Fr�ttingsdorf", "Ft"),
("Frauenberg a.d. Enns", "Fu"),
("Frauenkirchen", "Frk"),
("Frauental-Bad Gams", "Frt"),
("Freistadt", "Fr"),
("Friedberg", "Fd"),
("Friedburg", "Nsf"),
("Friesach", "Fi"),
("Fritzens-Wattens", "Fw"),
("Frohnleiten", "Fro"),
("F�rnitz", "Fn"),
("F�rstenfeld", "Fue"),
("Furth", "Mho%20H1"),
("Furth-G�ttweig", "Fh%20H1"),
("F�rth-Kaprun", "Fuk"),
("Furth-Palt", "Fh"),
("Gaflenz", "Ob%20K1"),
("Gaisbach-Wartberg", "Ga"),
("Gaishorn", "Gai"),
("Gaisruck", "Su%20H2A"),
("G�nserndorf", "Gae"),
("Garsten", "Gst"),
("Gars-Thunau", "Gas"),
("Gattendorf", "Gtt"),
("Gedersdorf", "Hfa%20K1"),
("Geinberg", "Gur%20H1"),
("Gemeinlebarn", "Mos%20H2"),
("Gerasdorf", "Gef"),
("Geras-Kottaun", "Lau%20H1"),
("Gerling im Pinzgau", "Z%20H1"),
("Gerling O�", "Rog%20H2"),
("Getzersdorf", "Tra%20H1"),
("Gie�enbach", "Set%20K1"),
("Gisingen", "Fk%20H2N"),
("Glandorf", "Vps%20H1"),
("Glanegg", "Gla"),
("Gleisdorf", "Gld"),
("Glei�enfeld", "Ses%20H1"),
("Glinzendorf", "Raf%20H1"),
("Gloggnitz", "Glo"),
("Gmunden", "Gz"),
("Gmunden Seebahnhof", "Gms"),
("Gmunden-Traundorf", "Enh%20H2"),
("Gm�nd N�", "Gm"),
("Gniebing", "Stu%20H2"),
("Gobelsburg", "Lis%20H1"),
("G�dersdorf", "Vo%20H1"),
("Goisern Jodschwefelbad", "Gj"),
("G�llersdorf", "Gr"),
("Golling-Abtenau", "Gg"),
("Gols", "Go"),
("G�pfritz", "Gf"),
("Gopperding", "Tp%20H2H"),
("G�rtschach-F�rolach", "Gtf"),
("Gosdorf", "Gof"),
("G�sing", "Gng"),
("G�tzendorf", "Goe"),
("G�tzis", "Got"),
("Grafendorf", "Gd"),
("Grafenstein", "Gra"),
("Gramatneusiedl", "Gn"),
("Granitztal", "Spa%20H2"),
("Gratwein-Gratkorn", "Gw"),
("Graz Don Bosco", "GboG%20H1"),
("Graz Hauptbahnhof", "G"),
("Graz K�flacherbahnhof", "Gkf"),
("Graz Liebenau-Murpark", "Gob%20H1"),
("Graz Ostbahnhof-Messe", "Gob"),
("Graz Puntigam", "Pu"),
("Graz Stra�gang", "Sgg"),
("Graz Webling", "Gkf%20H2"),
("Graz Wetzelsdorf", "Gkf%20H1"),
("Greifenburg-Wei�ensee", "Gre"),
("Greifenstein-Altenberg", "Kz%20H2"),
("Grein-Bad Kreuzen", "Gbk"),
("Greinsfurth", "Ams%20H1U"),
("Grein Stadt", "Ges"),
("Gresten", "Ogr"),
("Gries", "Sti%20K1"),
("Gries im Pinzgau", "Ta%20H1"),
("Grieskirchen-Gallspach", "Gk"),
("Grieswirt", "Fie%20H1"),
("Gr�bming", "Grb"),
("Gro�endorf", "Gdf"),
("Gro� Engersdorf", "Ged"),
("Gro� Gerungs", "Grg"),
("Gro�raming", "Grm"),
("Gro�raming Kraftwerk", "Rei%20H1"),
("Gro� St. Florian", "Gfl"),
("Gro� Schweinbarth", "Grs"),
("Gro� Sierning", "Sie"),
("Gro�weikersdorf", "Wk"),
("Gr�nau im Almtal", "Gue"),
("Gr�nbach am Schneeberg", "Gru"),
("Gr�nbach Kohlenwerk", "Gru%20H2"),
("Gr�nbach Schule", "Gru%20H1"),
("Gstadt", "Gsy"),
("Gstatterboden i. Nationalpark", "Gb"),
("Gummern", "Gu"),
("Gumpoldskirchen", "Md%20H2"),
("Gunskirchen", "Gun"),
("Guntersdorf", "Gud"),
("Guntramsdorf-Kaiserau", "Guk"),
("Guntramsdorf-Thallern", "Md%20H1"),
("Gurten", "Gur"),
("Gussendorf", "Pwd%20H1"),
("Gutenstein", "Gt"),
("Habachtal-Weyerhof", "Bbg%20H2"),
("Hadersdorf am Kamp", "Hfa"),
("Hagenau im Innkreis", "Mig%20H1"),
("Haiding", "Had"),
("Haiming", "Siz%20H1"),
("Hainburg a.d. Donau Kulturfabrik", "Hai"),
("Hainburg a.d. Donau Personenbf", "Hai%20H1"),
("Hainburg a.d. Donau Ungartor", "Hai%20H2"),
("Hainfeld", "Hn"),
("Halbenrain", "Hal"),
("Hallein", "Hl"),
("Hallein Burgfried", "Hl%20H1A"),
("Hall in Tirol", "H"),
("Hallstatt", "Oa%20H1"),
("Hall-Thaur", "H%20H1H"),
("Hallwang-Elixhausen", "Hw"),
("Hard-Fussach", "Us%20K1"),
("Hart bei Graz", "Mes%20H2"),
("Hartberg", "Har"),
("Hart im Innkreis", "Mn%20H1"),
("Hart-W�rth", "Wm%20H2"),
("Haselstauden", "Do%20H1"),
("Haslach", "Hah"),
("Haslau", "Hlu"),
("Hatlerdorf", "Hos%20H1"),
("Hatting", "Zl%20H1"),
("Hatzendorf", "Sou%20H2"),
("Haus", "Hau"),
("Hausleiten", "Su%20K1"),
("Hausruck", "Hs"),
("Hautzendorf", "Snb%20H1"),
("Heilbad Burgwies", "Slf%20H1"),
("Heiterwang-Plansee", "Bch%20H2H"),
("Helmahof", "Wg%20H1"),
("Hengsberg", "Hen"),
("Hengsth�tte", "Haz%20H1"),
("Hennersdorf", "Hnd"),
("Hermagor", "Her"),
("Herzogenburg", "Ho"),
("Herzogenburg Stadt", "Tra%20H2"),
("Herzogenburg-Wielandsthal", "Stf%20H1"),
("Herzograd", "Sv%20H1E"),
("Hessendorf Anglerparadies", "Wet%20H2"),
("Hetzmannsdorf-Wullersdorf", "Hm"),
("Hieflau", "Hi"),
("Hilm-Kematen", "Hk"),
("Himberg", "Him"),
("Hinterstoder", "Hst"),
("Hirschbach", "Vit%20H1"),
("Hirtenberg", "Ez%20H1"),
("H�bersdorf", "Si%20H1"),
("Hochfilzen", "Hch"),
("Hochschneeberg Bergbahnhof", "Hsc"),
("Hochzirl", "Hol"),
("Hofern", "R%20H1"),
("H�flein a.d. Donau", "Kz%20H1"),
("Hofstatt", "Hu%20H3"),
("Hofstetten-Gr�nau", "Hog"),
("Hohenau", "Nh"),
("Hohenberg", "Nh"),
("Hohenbrugg a.d. Raab", "Feg%20H1"),
("Hohenems", "Hos"),
("Hollabrunn", "Oh"),
("Hollenegg", "Dlb%20H1"),
("Hollersbach", "Hba"),
("Holzleithen", "Hon"),
("Hopfgarten", "Hp"),
("Hopfgarten Berglift", "Kit%20H3"),
("H�rersdorf", "Mb%20H3"),
("Horn", "Hna"),
("H�rsching", "Hoe"),
("H�tzelsdorf-Geras", "Hgr"),
("H�ttau", "Hue"),
("Iglm�hle", "Nef%20H2"),
("Imsterberg", "Im%20H1"),
("Imst-Pitztal", "Im"),
("Innsbruck Hauptbahnhof", "I"),
("Innsbruck H�tting", "Ih"),
("Innsbruck Westbahnhof", "Wt"),
("Inzing", "Zl%20H1"),
("Irnfritz", "Irn"),
("Irschen", "Od%20H1"),
("Jedenspeigen", "Due%20H1"),
("Jenbach", "Jb"),
("Jennersdorf", "Jd"),
("Jesdorf-Bergfried", "Ps%20H3"),
("Johnsbach i. Nationalpark", "Gb%20H1"),
("Jois", "Pur%20H3H"),
("Judenburg", "Jg"),
("Judendorf-Stra�engel", "Gw%20H1"),
("Kaindorf a.d. Sulm", "Grl%20H1"),
("Kainisch", "Kai"),
("Kalk�fen-Daxberg", "Had%20H4"),
("Kalsdorf", "Kal"),
("Kaltenbrunnen", "Amo%20H2"),
("Kalwang", "Kag"),
("Kamegg", "Hna%20H3"),
("Kammerhof", "Klg%20H2"),
("Kammern", "Sei%20H1"),
("Kammer-Sch�rfling", "Kms"),
("Kapellerfeld", "Gef%20H1"),
("Kapfenberg", "Ka"),
("Kapfenberg Fachhochschule", "Mas%20H1"),
("Kappel am Krappfeld", "Tr%20H1"),
("Karling", "Efd%20H4"),
("Kastenreith", "Wey%20H1"),
("Katsdorf", "Lu%20H1"),
("Katzelsdorf", "Nb%20H1"),
("Kefermarkt", "Kf"),
("Kematen a.d. Krems", "Kek"),
("Kematen in Tirol", "Vl%20K1"),
("Kimpling", "Neu%20H1"),
("Kindberg", "Ki"),
("Kirchberg a.d. Pielach", "Kip"),
("Kirchberg am Wagram", "Kch"),
("Kirchberg in Tirol", "Kit"),
("Kirchbichl", "Kir"),
("Kirchdorf a.d. Krems", "Kik"),
("Kirchstetten", "Krt"),
("Kittsee", "Ktt"),
("Kitzb�hel", "Kzb"),
("Kitzb�hel-Hahnenkamm", "Kzb%20H1"),
("Kitzsteinhornstra�e", "Tih%20H1"),
("Klagenfurt Annabichl", "Mal%20H1"),
("Klagenfurt Ebenthal", "Gra%20H1"),
("Klagenfurt Hauptbahnhof", "Kt"),
("Klagenfurt Lend", "Kt%20H1"),
("Klagenfurt Ostbahnhof", "Kto"),
("Klagenfurt S�d", "Kt%20H1A"),
("Klagenfurt West", "Kt%20H2"),
("Klamm-Schottwien", "Ks"),
("Klangen", "Klg"),
("Klaus", "Kus"),
("Klaus in Vorarlberg", "Rk%20K1"),
("Kleblach-Lind", "Kel"),
("Kledering", "Za"),
("Kleinreifling", "Kg"),
("Kleinzell", "Nen%20H1"),
("Klosterneuburg-Kierling", "Ken%20H1"),
("Klosterneuburg-Weidling", "Ken"),
("Knittelfeld", "Kd"),
("K�flach", "Kfl"),
("Kolbnitz", "Kl"),
("K�ppling", "Smk%20H1"),
("Korneuburg", "Ko"),
("Kothm�hle", "Ssm%20H1"),
("Kottingbrunn", "Bvs%20H1"),
("Kottingneusiedl", "Enz%20H1"),
("Kranebitten", "Ih%20H2"),
("Kraubath", "Kra"),
("Kreisbach", "Trn%20H3"),
("Krems a.d. Donau", "Kr"),
("Krems Campus-Kunstmeile", "Kr%20H1"),
("Krems in Steiermark", "Kro%20K1"),
("Kremsm�nster", "Kre"),
("Krenstetten-Biberbach", "Ams%20H3"),
("Krieglach", "Ke"),
("Krimml", "Krl"),
("Kritzendorf", "Kz"),
("Kr�llendorf", "Ul%20H1"),
("Krottendorf-Ligist", "Kro"),
("Krummnu�baum", "Poe%20H1"),
("Krumpendorf", "Krd"),
("K�b", "Pr%20H1"),
("Kuchl", "Hl%20H5"),
("Kuchl Garnei", "Hl%20H3"),
("Kufstein", "K"),
("Kumpfm�hl", "Neu%20H2"),
("Kundl", "Kn"),
("K�pfern", "Grm%20H1"),
("Laa a.d. Thaya", "Laa"),
("Lacken", "Rog%20H1"),
("Ladendorf", "Ldf"),
("L�hn", "Ler%20H1"),
("Lahnsiedlung", "Wap%20H2"),
("Lahnstein", "Law%20H1"),
("Lah�fen", "Had%20H5"),
("Lahrndorf", "Lf"),
("Lambach", "La"),
("Lambach Markt", "La%20H1"),
("Landeck-Zams", "Le"),
("Langau", "Lau"),
("Langen am Arlberg", "Lan"),
("Langenlebarn", "Aw%20H3"),
("Langenlois", "Lis"),
("Langenwang", "Mz%20K1"),
("Langenzersdorf", "J%20H1"),
("Langkampfen", "K%20H2"),
("Langschlag", "Lag"),
("Langwies", "Law"),
("Lannach", "Lnn"),
("Lanzendorf-Rannersdorf", "Zs"),
("Lanzenkirchen", "Kw"),
("Lasberg-St. Oswald", "Kf%20H1"),
("La�nitzh�he", "Lah"),
("La�nitzthal", "Lah%20H1"),
("Laubenbachm�hle", "Lae"),
("Lauffen", "Gj%20H1"),
("Launsdorf-Hochosterwitz", "Lad"),
("Lauterach", "Lsa%20H1"),
("Laxenburg-Biedermannsdorf", "Lx"),
("Lebring", "Wi%20H1"),
("Ledenitzen", "Lez"),
("Ledenitzen West", "Fas%20H1"),
("Lehen-Altensam", "At%20H1"),
("Leibnitz", "Lei"),
("Leithen", "Hol%20H1"),
("Lend", "Ld"),
("Lendorf", "Ssn%20H1"),
("Lengau", "Nst%20H1A"),
("Lengdorf", "Nsi%20H1"),
("Lenzing", "Lng"),
("Lenzing Ort", "Lng%20H1"),
("Leobendorf-Burg Kreuzenstein", "Ko%20H1"),
("Leoben Hauptbahnhof", "Leb"),
("Leobersdorf", "Lb"),
("Leogang", "Saa%20H2"),
("Leogang-Steinberge", "Saa%20H1"),
("Leonding", "Lz%20H1"),
("Lermoos", "Ler"),
("Leum�hle", "Efd%20H2"),
("Lichendorf", "Sd%20H2"),
("Liebenfels", "Vs%20H2"),
("Lieboch", "Lbo"),
("Lieboch Schadendorf", "Lbo%20H1"),
("Lienz", "Lie"),
("Lienz-Peggetz", "Lie%20H1"),
("Liezen", "Ln"),
("Lilienfeld", "Lil"),
("Lilienfeld Krankenhaus", "Shr%20H1"),
("Limberg-Maissau", "Lim"),
("Lind-Rosegg", "Vel%20H1"),
("Lind-Scheifling", "Niz%20H1"),
("Linz Ebelsberg", "Ast%20H2"),
("Linz Franckstra�e", "Lfs"),
("Linz Hauptbahnhof", "Lz"),
("Linz Oed", "Lz%20H1W"),
("Linz-Pichling", "Ast%20H1"),
("Linz Urfahr", "Uf"),
("Linz Wegscheid", "Wd"),
("Litschau", "Lit"),
("Lochau-H�rbranz", "Lc"),
("L�dersdorf", "Fb%20H1"),
("Loich", "Loi"),
("Loipersbach-Schattendorf", "Ls"),
("Loosdorf", "Los"),
("Lor�ns", "Lor%20H1"),
("Losenstein", "Lon"),
("Ludesch", "Lt"),
("Lungitz", "Lu"),
("Lustenau", "Us"),
("Maishofen-Saalbach", "Z%20K1"),
("Mallnitz-Obervellach", "Ma"),
("Mandling", "Mdg"),
("Mannsw�rth", "Kls%20H2"),
("Marchegg", "Mac"),
("Marchtrenk", "Mak"),
("Marein-St. Lorenzen", "Mas"),
("Maria Anzbach", "Hu%20H2"),
("Maria Ellend a.d. Donau", "Mae"),
("Mariahof-St. Lambrecht", "Mah"),
("Maria Lanzendorf", "Mar"),
("Maria Rain", "Kt%20H3"),
("Maria Saal", "Mal"),
("Mariazell", "Maz"),
("Markersdorf a.d. Pielach", "Pd%20H1"),
("Marktl", "Lil%20H1"),
("Markt Paternion", "Ro%20H2"),
("Markt Sachsenburg", "Kel%20H1"),
("Marz-Rohrbach", "Mr%20H1"),
("Matrei", "Mei"),
("Mattersburg", "Mr"),
("Mattersburg Nord", "Sau%20H2"),
("Mattighofen", "Mho"),
("Matzen", "Gae%20H2A"),
("Mauerkirchen", "Mau"),
("Mauer-�hling", "Ams%20H1"),
("Mautbr�cken", "Gla%20H1"),
("Mautern", "Mu"),
("Mauthausen", "Mh"),
("Melk", "Ml"),
("Micheldorf", "Mid"),
("Micheldorf-Hirt", "Fi%20H1"),
("Michelhausen", "Tfd%20H1"),
("Miesenbach-Waidmannsfeld", "Oed%20H1"),
("Mining", "Mig"),
("Mistelbach", "Mb"),
("Mistelbach Stadt", "Mb%20H1H"),
("Mitterbach", "Mit"),
("Mitterbergh�tten", "Bo%20H1"),
("Mitterdorf-Veitsch", "Mv"),
("Mitterwei�enbach", "Mib"),
("Mittewald a.d. Drau", "Abf%20K1"),
("Mittlern", "Ble%20H2"),
("Mixnitz-B�rensch�tzklamm", "Mx"),
("M�dling", "Md"),
("Mogersdorf", "Mog"),
("M�llbr�cke-Sachsenburg", "Ssn"),
("M�llersdorf Aspangbahn", "Guk%20H2"),
("M�nchhof-Halbturn", "Mhf"),
("Moosbierbaum-Heiligeneich", "Mos"),
("M�tz", "Sts%20H1"),
("Muckendorf-Wipfing", "Aw%20H2"),
("M�hldorf-M�llbr�cke", "Kl%20H1"),
("M�hlheim", "Ath%20H1"),
("M�hling", "Wie%20H1"),
("M�hling-Plaika", "Wie%20H2"),
("M�llendorf", "Mld"),
("M�nchendorf", "Mue"),
("Munderfing", "Mun"),
("Munderfing Dampfs�ge", "Nst%20H4A"),
("M�nster-Wiesing", "Bri%20H1"),
("Mureck", "Mug"),
("M�rzzuschlag", "Mz"),
("Musau", "Rt%20H2"),
("Nenzing", "Lt%20K1"),
("Nettingsdorf", "Net"),
("Neubau-Kreuzstetten", "N"),
("Neudorf", "Par%20H1"),
("Neud�rfl", "Nel"),
("Neufeld a.d. Leitha", "Nfl"),
("Neufelden", "Nef"),
("Neuhaus a.d. Gail", "Fn%20H1"),
("Neuhaus-Niederwaldkirchen", "Nen"),
("Neuhofen a.d. Krems", "Nkr"),
("Neukirchen am Gro�venediger", "Ner"),
("Neukirchen bei Lambach", "La%20H2"),
("Neukirchen-Gampern", "Tm%20H1"),
("Neulengbach", "Nl"),
("Neulengbach Stadt", "Hu%20H4"),
("Neumarkt a.d. Ybbs-Karlsbach", "Y%20H1"),
("Neumarkt in Steiermark", "Nes"),
("Neumarkt-Kallham", "Neu"),
("Neumarkt am Wallersee", "Nsk"),
("Neunkirchen N�", "Nek"),
("Neuratting", "Rd%20H3"),
("Neusiedl am See", "Ns"),
("Nickelsdorf", "Nif"),
("Nieder Fladnitz", "Nie"),
("Niederkreuzstetten", "Snb%20H2"),
("Niedernfritz-St. Martin", "Ebn%20H1"),
("Niedernsill", "Nsi"),
("Nieder�blarn", "Mag%20H1"),
("Niederw�lz-Oberw�lz", "Niz"),
("Niklasdorf", "Ni"),
("Nikolsdorf", "Doe%20H1"),
("N�StBach-St. Marien", "Net%20H1"),
("N�tsch", "Noe"),
("Nu�bach", "Wak%20H1"),
("N�ziders", "B%20H1"),
("Oberalm", "Aj%20H5"),
("Oberbrunn", "Ew%20H1"),
("Oberdrauburg", "Od"),
("Obereggendorf", "Ed"),
("Oberfalkenstein", "Ma%20H1"),
("Ober Grafendorf", "Ogr"),
("Oberhart", "Sth%20H1"),
("Oberhofen im Inntal", "Zl%20H3"),
("Oberhofen-Zell am Moos", "Edb%20H1"),
("Oberland Haltestelle", "Ob%20H1H"),
("Obernberg-Altheim", "Ath"),
("Oberndorf in Tirol", "Jti%20H1"),
("Ober Olberndorf", "Su%20H1"),
("Ober Piesting", "Op"),
("Oberradlberg", "Ho%20H1"),
("Obersdorf", "Odf"),
("Obersdorf Haltestelle", "Gef%20H3"),
("Obersee", "Oa%20H2"),
("Oberthalheim-Timelkam", "Vk%20H1"),
("Obertrattnach-Markt Hofkirchen", "Gk%20H1"),
("Obertraun-Dachsteinh�hlen", "Oa"),
("Obertraun-Koppenbr�llerh�hle", "Au%20H1"),
("Ober Waltersdorf", "Ti%20K2"),
("Oberwart", "Obw"),
("Oberweiden", "On"),
("�blarn", "Oeb"),
("Oed", "Oed"),
("Oepping", "Oep"),
("Oftering", "Hoe%20H1"),
("Oisnitz-St. Josef", "Lnn%20K1"),
("Ollersbach", "Nl%20H1"),
("Ortmann", "Ort"),
("Ossiach-Bodensdorf", "Oi"),
("Ottensheim", "Ott"),
("Ottnang-Wolfsegg", "Otg"),
("�tztal", "Oz"),
("Paasdorf", "Ldf%20H1"),
("Pama", "Gtt%20H1"),
("Pamhagen", "Pam"),
("Parndorf", "Par"),
("Parndorf Ort", "Apo%20H1"),
("Pasching", "Lz%20H2"),
("Passering", "Tr%20H2"),
("Paternion-Feistritz", "Pf"),
("Paternion-Feistritz Haltestelle", "Pf%20H1A"),
("Patsch", "I%20H2"),
("Paudorf", "Pau"),
("Payerbach-Reichenau", "Pr"),
("Peggau-Deutschfeistritz", "Pg"),
("Penk", "Pk"),
("Perchtoldsdorf (Haltestelle)", "Lg%20H1"),
("Perg", "P"),
("Perg Schulzentrum", "Arb%20H1"),
("Pernegg", "Pn"),
("Pernitz-Muggendorf", "Pem"),
("Pernitz Raimundviertel", "Pem%20H1"),
("Pernitz Wipfelhofstra�e", "Ort%20H1"),
("Petersbaumgarten", "Sgk%20H1"),
("Peterskirchen", "Pra%20H1"),
("Petronell-Carnuntum", "Pet"),
("Pettenbach", "Peb"),
("Petzenkirchen", "Erf%20H1"),
("Pfaffenschwendt", "Hch%20H1"),
("Pfaffst�tten", "Bf"),
("Pfarrwerfen", "Rf%20H1"),
("Pfennigbach", "Gru%20H3"),
("Pflach", "Rt%20H1"),
("Pichl", "Pic"),
("Piesendorf", "Ps"),
("Piesendorf Bad", "Ps%20H1"),
("Piesting", "Pie"),
("Piesting Harzwerk", "Woe%20H2"),
("Pillichsdorf", "Odf%20H1"),
("Pill-Vomperbach", "Sw%20K1"),
("Pinggau Markt", "Tau%20H1"),
("Pinsdorf", "Gz%20H1"),
("Pirtendorf", "Ut%20H1"),
("Pitten", "Ptt"),
("Pixendorf", "Tus%20H1"),
("Plank am Kamp", "Plk"),
("Platt", "Gud%20H1"),
("Plei�ing-Waschbach", "Nie%20K1"),
("P�chlarn", "Poe"),
("P�ckau", "Vw%20H2"),
("P�ham", "Ph"),
("P�lfing-Brunn", "Pfb"),
("P�ndorf", "Fm%20H1"),
("P�rtschach am W�rthersee", "Pow"),
("Pottenbrunn", "Wgm"),
("Pottendorf-Landegg", "Wp%20H1"),
("Pottenstein a.d. Triesting", "Pt"),
("Pottschach", "Tn%20H1"),
("Pram-Haag", "Pra"),
("Preding-Wieselsdorf", "Pwd"),
("Pregarten", "Pre"),
("Premst�tten-Tobelbad", "Pms"),
("Pressbaum", "Pm%20H1"),
("Pressegger See", "Gtf%20H1"),
("Prinzersdorf", "Pd"),
("Pritschitz", "Krd%20H1"),
("Prottes", "Gae%20K1A"),
("Pruggern", "Grb%20H1"),
("Puch bei Hallein", "Aj%20H4"),
("Puch bei Villach", "Pf%20H2"),
("Puchberg am Schneeberg", "Pub"),
("Puchenau", "Uf%20H1"),
("Puchenau West", "Puw"),
("Puchenstuben", "Lae%20K2"),
("Puch Urstein", "Aj%20H3A"),
("Pulgarn", "Sy%20H1"),
("Pupping", "Efd%20H3"),
("Purbach am Neusiedlersee", "Pur"),
("P�rbach-Schrems", "Pue"),
("P�rgg", "Rg%20H1K"),
("Purgstall", "Pus"),
("Purkersdorf Sanatorium", "Hf%20H3H"),
("Purkersdorf Zentrum", "Up%20H1"),
("Purkla", "Gof%20H3"),
("Pusarnitz", "Uz"),
("Raaba", "Mes%20H1"),
("Raasdorf", "Raf"),
("Rabensburg", "Nh%20H1"),
("Rabenstein", "Rab"),
("Radstadt", "Rad"),
("Raggendorf", "Gae%20H3A"),
("Raggendorf Markt", "Bof%20H2"),
("Rainfeld-Klein Zell", "Hn%20H2"),
("Ramingdorf-Haidershofen", "Rh"),
("Rankweil", "Rk"),
("Rattenberg-Kramsach", "W%20H1"),
("Redl-Zipf", "Rz"),
("Regelsbrunn", "Reg"),
("Reichraming", "Rei"),
("Reith", "Re"),
("Rekawinkel", "Rw"),
("Rettenbach", "Mil%20H1"),
("Retz", "R"),
("Reutte in Tirol", "Rt"),
("Reutte in Tirol Schulzentrum", "Bch%20H4"),
("Riedau", "Ri"),
("Riedenburg", "Lna%20H1"),
("Ried im Innkreis", "Rd"),
("Rietz", "Ts%20H1"),
("Rohr", "Stu%20H1"),
("Rohrbach a.d. G�lsen", "Hn%20H1"),
("Rohrbach-Berg", "Rob"),
("Rohrbach-Vorau", "Rv"),
("Rohr-Bad Hall", "Rr"),
("Rohrendorf", "Hfa%20H1"),
("Roppen", "Rop"),
("Rosenau", "Hk%20H1"),
("Rosenbach", "Rn"),
("Rosenburg", "Hna%20H1"),
("Rosental", "Ner%20H2"),
("Ro�leithen", "Piv%20K1"),
("Rothengrub", "Wil%20H1A"),
("Rothenthurn", "Ro"),
("Rottenegg", "Rog"),
("Rum", "H%20H1"),
("Saalfelden", "Saa"),
("Saffen", "Pus%20H2"),
("Salzburg Aigen", "Aj"),
("Salzburg Aiglhof", "Sba"),
("Salzburg Gnigl", "Sr%20H1"),
("Salzburg Hauptbahnhof", "Sb"),
("Salzburg Kasern", "Hw%20H1"),
("Salzburg Liefering", "Lfg"),
("Salzburg M�lln-Altstadt", "Sbj"),
("Salzburg Parsch", "Sr%20H2"),
("Salzburg Sam", "Sbm%20H1"),
("Salzburg S�d", "Aj%20H1"),
("Salzburg Taxham Europark", "Sbe"),
("Sand", "Gst%20H1"),
("St. Aegyd am Neuwalde", "Ey"),
("St. Andr� am Zicksee", "Saz"),
("St. Andr� im Lavanttal", "An"),
("St. Andr�-W�rdern", "Aw"),
("St. Anton am Arlberg", "Ao"),
("St. Egyden", "Nb%20H1S"),
("St. Georgen a.d. Gusen", "Sge"),
("St. Georgen a.d. Gusen Haltestelle", "Sge%20H1"),
("St. Georgen a.d. Mattig", "Mau%20H1"),
("St. Georgen am L�ngsee", "Lad%20H1"),
("St. Georgen am Steinfelde", "Wm%20H1"),
("St. Georgen ob Judenburg", "Tel%20H1"),
("St. Jodok", "Sti%20H1"),
("St. Johann im Pongau", "Jp"),
("St. Johann in der Haide", "Gd%20H1"),
("St. Johann in Tirol", "Jti"),
("St. Johann-Weistrach", "Sp%20H1"),
("St. Martin bei Traun", "Wd%20H1"),
("St. Martin i.S.-Bergla", "Bgl"),
("St. Martin im Innkreis", "Mn"),
("St. Martin-Sittich", "Sms"),
("St. Michael", "M"),
("St. Michael ob Bleiburg", "Ble%20H1"),
("St. Nikola-Struden", "Nk"),
("St. Pantaleon", "Mh%20H1"),
("St. Paul", "Spa"),
("St. Paul Bad", "Spa%20H1"),
("St. Peter-Seitenstetten", "Sp"),
("St. P�lten Hauptbahnhof", "Pb"),
("St. P�lten-Kaiserwald", "Pl"),
("St. P�lten-Porschestra�e", "Spr%20H2"),
("St. P�lten-Traisenpark", "Vn%20H1"),
("St. Stefan im Lavanttal", "Ssl"),
("St. Stefan-Vorderberg", "Ssv"),
("St. Urban am Ossiachersee", "Oi%20H1"),
("St. Valentin", "Sv"),
("St. Veit a.d. Glan", "Vps"),
("St. Veit a.d. Glan Westbahnhof", "Vs"),
("St. Veit a.d. G�lsen", "Vg"),
("St. Veit a.d. Triesting", "Ez%20H2"),
("Sarasdorf", "Goe%20H1"),
("Sarmingstein", "San"),
("Sattendorf", "Saf"),
("Sattledt", "Sad"),
("S�usenstein", "Poe%20H2"),
("Sautern-Schiltern", "Ptt%20H1"),
("Saxen", "Ax"),
("Schaftenau", "K%20H1"),
("Schalchen-Mattighofen", "Mun%20H1"),
("Sch�rding", "Sch"),
("Scharnitz", "Snz"),
("Scharnstein-M�hldorf", "Ssm"),
("Schauboden", "Wie%20H3"),
("Schauersberg", "Scb"),
("Scheibbs", "Sbs"),
("Scheiblingkirchen-Warth", "Sgk"),
("Scheifling", "Sf"),
("Schiflugschanze Kulm", "Ku%20H1Hst"),
("Schladming", "Sdg"),
("Schl�gl", "Oep%20H1"),
("Schleinbach", "Snb"),
("Schlierbach", "Srb"),
("Schlins-Beschling", "Lt%20H2"),
("Schl�glm�hl", "Glo%20H1"),
("Schlo� Haus", "Ga%20H1"),
("Schl��lberg", "Wa%20H1"),
("Sch�nberg am Kamp", "Sbk"),
("Sch�nborn-Mallebarn", "Si%20H2"),
("Sch�nfeld-Lassee", "Sfl"),
("Sch�nwies", "Ss"),
("Schrambach", "Shr"),
("Sch�tzen am Gebirge", "Sag"),
("Sch�tzen Haltestelle", "Sag%20H1"),
("Schwanenstadt", "Sas"),
("Schwarza", "Sd%20H1"),
("Schwarzach in Vorarlberg", "Do%20H2"),
("Schwarzach-St. Veit", "Swa"),
("Schwarzenau", "Swu"),
("Schwarzsee", "Kzb%20H2"),
("Schwaz", "Sw"),
("Schwechat", "Gs"),
("Schwertberg", "Swb"),
("Sebersdorf", "Seb"),
("Seebenstein", "Ses"),
("Seefeld in Tirol", "Set"),
("Seekirchen am Wallersee", "See"),
("Seekirchen am Wallersee Stadt", "See%20H1H"),
("Selzthal", "Sl"),
("Semmering", "Sem"),
("Seyring", "Gef%20H2"),
("Siebenbrunn-Leopoldsdorf", "Sbl"),
("Siebenhirten N�", "Mb%20H2H"),
("Siebenm�hlen-Rosenau", "Lng%20H2"),
("Sierndorf", "Si"),
("Sierndorf a.d. March", "Due%20H2"),
("Sigmundsherberg", "Sh"),
("Silberwald", "Str%20H1"),
("Sillian", "Sil"),
("Silz", "Siz"),
("Sitzenberg-Reidling", "Mos%20K1"),
("S�chau", "Sou"),
("S�ding-Mooskirchen", "Smk"),
("Sollenau", "Lb%20H1"),
("S�lling", "Pus%20H1"),
("Sonntagberg", "Hk%20H2"),
("Spielberg", "Kd%20H1"),
("Spielfeld-Stra�", "Sd"),
("Spillern", "Ko%20H2"),
("Spital am Pyhrn", "Spi"),
("Spital am Semmering", "Sps"),
("Spittal-Millst�ttersee", "Stt"),
("Spratzern", "Spr"),
("Staatz", "Enz%20K1"),
("Stadl-Paura", "Stp"),
("Stadt Haag", "Ha%20H1"),
("Stadt Rottenmann", "Rm%20H1"),
("Stadt Waidhofen a.d. Ybbs", "Wh%20H1"),
("Stainach-Irdning", "Rg"),
("Stallegg", "Hna%20H2"),
("Stams", "Sts"),
("Stans bei Schwaz", "Jb%20H1"),
("Statzendorf", "Stf"),
("Steeg-Gosau", "Stg"),
("Stein a.d. Enns", "Oeb%20K1"),
("Steinach in Tirol", "Sti"),
("Steinbachbr�cke", "Sbb"),
("Steindorf am Ossiachersee", "Sos"),
("Steindorf bei Stra�walchen", "Nst"),
("Steinfeld im Drautal", "Std"),
("Steinhaus", "Sem%20H1"),
("Steinhaus bei Wels", "Sth"),
("Steinkogel", "Law%20H2"),
("Stetten Fossilienwelt", "Ste"),
("Steyr", "Stb"),
("Steyregg", "Sy"),
("Steyrling", "Sng"),
("Steyr-M�nichholz", "Sbw%20H1"),
("Stiefern", "Plk%20H2"),
("Stillfried", "Ag%20H1"),
("Stockerau", "Su"),
("Strasshof", "Wg%20H2"),
("Stra�walchen", "Stw"),
("Stra�walchen West", "Nst%20H1H"),
("St�bing", "Pg%20H1"),
("Studenzen-Fladnitz", "Stu"),
("Suben", "Ant%20H2"),
("S��enbrunn", "Sue"),
("Sulz-R�this", "Rk%20H1"),
("Summerau", "Smr"),
("Tainach-Stein", "Tas"),
("Takern-St. Margarethen", "Tak"),
("Tallesbrunn", "Gae%20H2"),
("Tassenbach", "Sil%20H1"),
("Tattendorf", "Tat"),
("Tauchendorf-Haidensee", "Lif%20H1"),
("Tauchen-Schaueregg", "Tau"),
("Taufkirchen a.d. Pram", "Tp"),
("Tauplitz", "Ku"),
("Taxenbach-Rauris", "Ta"),
("Teesdorf", "Tdf"),
("Teichst�tt", "Nst%20H2A"),
("Telfs-Pfaffenhofen", "Ts"),
("Tenneck", "Gg%20K2"),
("Terfens-Weer", "Sw%20H1"),
("Ternberg", "Te"),
("Ternitz", "Tn"),
("Thal", "Tl"),
("Thalheim-P�ls", "Tel"),
("Theresienfeld", "Fld%20H1"),
("Tiffen", "Fel%20H1"),
("Timelkam", "Tm"),
("Tischlerh�usl", "Tih"),
("Tisis", "Fk%20H3N"),
("T�schling", "Pow%20H1"),
("Traisen", "Trn"),
("Traisen Markt", "Lil%20H2"),
("Traiskirchen Aspangbahn", "Ti"),
("Traismauer", "Tra"),
("Trasdorf", "Mos%20H1"),
("Trattenbach", "Te%20H1"),
("Traun", "T"),
("Traunkirchen", "Tk"),
("Traunkirchen Ort", "En%20H2"),
("Trautmannsdorf a.d. Leitha", "Goe%20H1A"),
("Traxenbichl", "Tx"),
("Treibach-Althofen", "Tr"),
("Trieben", "Tb"),
("Trumau", "Ti%20K1"),
("Tschagguns", "Amo%20K1"),
("Tulln a.d. Donau", "Tu"),
("Tullnerbach-Pressbaum", "Pm"),
("Tullnerfeld", "Tfd"),
("Tulln Stadt", "Tus"),
("�belbach", "Ueb"),
("�bersbach", "Fue%20H1"),
("Ulmerfeld-Hausmening", "Ul"),
("Ulrichsbr�cke-F�ssen", "Rt%20H3"),
("Ulrichskirchen", "Wol%20H1"),
("Unterberg-Stefansbr�cke", "I%20H1"),
("Unter Buchberg", "Lae%20H1"),
("Untereggendorf", "Ef%20H1"),
("Untergaumberg", "Lz%20H1S"),
("Unterhart", "Uh"),
("Unter H�flein", "Wil%20H1"),
("Unter Kritzendorf", "Ken%20H2"),
("Unter Oberndorf", "Hu%20H1"),
("Unter Purkersdorf", "Up"),
("Unterradlberg", "Ho%20K1"),
("Unterretzbach", "R%20H1H"),
("Untersiebenbrunn", "Sbl%20H1"),
("Unter Tullnerbach", "Up%20H2"),
("Unzmarkt", "Um"),
("Urschendorf", "Wz%20H1"),
("Uttendorf-Helpfau", "Mho%20K1"),
("Vandans", "Amo%20H1"),
("Velden am W�rthersee", "Vel"),
("Vellach-Kh�nburg", "Gtf%20H2"),
("Viechtwang", "Viw"),
("Viehofen", "Vn"),
("Viktring", "Kt%20H2"),
("Villach Hauptbahnhof", "Vb"),
("Villach Landskron", "Ru"),
("Villach St. Ruprecht", "Ru"),
("Villach Seebach", "Foe%20H1"),
("Villach Warmbad", "Vf%20H1"),
("Villach Westbahnhof", "Vf"),
("Vils Stadt", "Vi%20H1A"),
("Vitis", "Vit"),
("V�cklabruck", "Vk"),
("V�cklamarkt", "Vm"),
("Voitsberg", "Vob"),
("Voitsdorf", "Voi"),
("Volders-Baumkirchen", "Fw%20H1"),
("V�lkermarkt-K�hnsdorf", "Vok"),
("V�ls", "Vl"),
("Vorchdorf-Eggenberg", "Vo%20Z9"),
("Wagram-Grafenegg", "Fs%20H1"),
("Waidhofen a.d. Ybbs", "Wh"),
("Wald am Schoberpa�", "Was"),
("Waldegg", "Wag"),
("Waldegg-D�rnbach", "Wag%20H1"),
("Walding", "Ott%20H1"),
("Wallern im Burgenland", "Wal"),
("Wallersee", "Nst%20H2"),
("Wampersdorf", "Wp"),
("Wankham", "Ak%20H1"),
("Wartberg a.d. Krems", "Wak"),
("Wartberg im M�rztal", "War"),
("Weiden am See", "Wds"),
("Weigelsdorf", "Ebr%20H1"),
("Weikendorf", "Gae%20H1M"),
("Weikendorf-D�rfles", "Gae%20H1"),
("Weinburg", "Klg%20H1"),
("Weins-Isperdorf", "Wki"),
("Weissenbach-Neuhaus", "Web"),
("Wei�enbach-St. Gallen", "Weg"),
("Wei�enkirchen in der Wachau", "Wki"),
("Weissenstein-Kellerberg", "Pf%20H2A"),
("Weitersfeld a.d. Mur", "Wem"),
("Weitersfeld N�", "Wet"),
("Weitlanbrunn", "Sc%20H3"),
("Weitra", "Wra"),
("Weizelsdorf", "Wef"),
("Wels Hauptbahnhof", "We"),
("Wels Lokalbahn", "Wl"),
("Wels Messe", "Wl%20H1"),
("Wendling", "Neu%20H1P"),
("Weng", "Nst%20H1"),
("Wenns", "Mp%20H1"),
("Werfen", "Rf"),
("Werndorf", "Wr"),
("Wernstein", "Wer"),
("Westendorf", "Kit%20H1A"),
("Wettmannst�tten", "Wtt"),
("Weyer", "Wey"),
("Wien Aspern Nord", "St%20H2"),
("Wien Atzgersdorf", "Az%20H1"),
("Wien Blumental", "Id"),
("Wien Breitensee", "Ok%20H1"),
("Wien Br�nner Stra�e", "F%20H1S"),
("Wienerbruck-Josefsberg", "Gng%20H1"),
("Wien Erzherzog-Karl-Stra�e", "Stk"),
("Wien Floridsdorf", "F"),
("Wien Franz-Josefs-Bahnhof", "Wf"),
("Wien Geiselbergstra�e", "Sah%20H1"),
("Wien Gersthof", "Ht%20H3"),
("Wien Grillgasse", "Sg"),
("Wien Hadersdorf", "Hf%20H2"),
("Wien Haidestra�e", "Wbf%20H2"),
("Wien Handelskai", "HakNw%20H2"),
("Wien Hauptbahnhof", "WbfWsp"),
("Wien Heiligenstadt", "Ht"),
("Wien Hernals", "Hns"),
("Wien Hetzendorf", "Het"),
("Wien Hirschstetten", "Stc"),
("Wien H�tteldorf", "Hf"),
("Wien Jedlersdorf", "J"),
("Wien Kaiserebersdorf", "Klf"),
("Wien Krottenbachstra�e", "Ht%20H2"),
("Wien Leopoldau", "Lp"),
("Wien Liesing", "Lg"),
("Wien Matzleinsdorfer Platz", "Wbf%20H1S"),
("Wien Meidling", "Mi"),
("Wien Mitte", "HzCat"),
("Wien Nordwestbahnhof", "Bw"),
("Wien Nu�dorf", "Nf"),
("Wien Oberd�bling", "Ht%20H1"),
("Wien Ottakring", "Ok"),
("Wien Penzing", "Pz"),
("Wien Praterkai", "El%20H1"),
("Wien Praterstern", "Nw"),
("Wien Quartier Belvedere", "Wwb"),
("Wien Rennweg", "Ren"),
("Wien St. Marx (Vienna Bio Center)", "Nw%20H1H"),
("Wien Siemensstra�e", "F%20H1"),
("Wien Simmering", "Wbf%20H1"),
("Wien Speising", "Hf%20H1A"),
("Wien Spittelau", "Wf%20H1"),
("Wien Stadlau", "El%20H3"),
("Wien Strebersdorf", "Sdf"),
("Wien Traisengasse", "Nw%20H1"),
("Wien Unter-D�bling", "UD"),
("Wien Weidlingau", "Hf%20H3"),
("Wien Westbahnhof", "Ws"),
("Wien Wolf in der Au", "Hf%20H1"),
("Wien Zentralfriedhof", "Cf"),
("Wiener Neustadt Anemonensee", "Nb%20H1A"),
("Wiener Neustadt Civitas Nova", "Ed%20H1"),
("Wiener Neustadt Hauptbahnhof", "Nb"),
("Wiener Neustadt Nord", "Fld%20H2"),
("Wies-Eibiswald", "Wew"),
("Wieselburg a.d. Erlauf", "Wie"),
("Wiesenfeld-Schwarzenbach", "Vg%20H1"),
("Wiesen-Sigle�", "Sau%20K1"),
("Wies Markt", "Pfb%20H1"),
("Wiesm�hle", "Gdf%20H1"),
("Wildon", "Wi"),
("Wildungsmauer", "Reg%20H1"),
("Wilfleinsdorf", "Goe%20H2"),
("Wilfling", "Voi%20H2"),
("Wilhelmsburg a.d. Traisen", "Wm"),
("Willendorf", "Wil"),
("Windau", "Kit%20H2"),
("Winden", "Pur%20H2H"),
("Windischgarsten", "Win"),
("Winkl im Rosental", "Lez%20H1"),
("Winzendorf", "Wz"),
("Wittmannsdorf", "Wit"),
("Wolfsberg", "Wog"),
("Wolfsberg Reding", "Wog%20H1"),
("Wolfsbergkogel", "Bt%20H1"),
("Wolfsh�tte", "At%20H2"),
("Wolfsthal", "Wof"),
("Wolfurt", "Wo"),
("Wolkersdorf", "Wol"),
("W�llersdorf", "Woe"),
("W�llersdorf-Marchgraben", "Woe%20H1A"),
("Wopfing", "Op%20H1"),
("W�rgl Hauptbahnhof", "W"),
("W�rgl S�d - Bruckh�usl", "Hp%20H1"),
("W�rschach Schwefelbad", "Ln%20H1"),
("Wulkaprodersdorf", "Wul"),
("Wulkaprodersdorf Haltestelle", "Wul%20H1H"),
("Ybbs an der Donau", "Y"),
("Zeiselmauer-K�nigstetten", "Aw%20H1"),
("Zell a.d. Pram", "Ri%20H1"),
("Zell am See", "Z"),
("Zellerndorf", "Zd"),
("Zeltweg", "Zg"),
("Ziersdorf", "Zf"),
("Zirl", "Zl"),
("Z�bing", "Sbk%20H1"),
("Zurndorf", "Zu")
};

        const string favoritenSchluessel = "Favoriten";
        public static Windows.Storage.ApplicationDataContainer einstellungen = Windows.Storage.ApplicationData.Current.LocalSettings;
        string favorisierteStationen = string.Empty; // \n-getrennt
        private void StationsNamensListe_Loaded(object sender, RoutedEventArgs e)
        {
            if (einstellungen.Values[favoritenSchluessel] != null && einstellungen.Values[favoritenSchluessel].ToString()!.Length > 1)
            {
                var s = einstellungen.Values[favoritenSchluessel].ToString();
                if (s == null) return;
                favorisierteStationen += s;
                StationsNamensListe.ItemsSource = favorisierteStationen.Split('\n');
                return;
            }

            StationsNamensListe.ItemsSource = alleStationen.Select(Station => Station.name);
        }

        private void StationsSuchFeld_Loaded(object sender, RoutedEventArgs e)
        {
            StationsSuchFeld.Focus(FocusState.Programmatic);
        }

        private void StationsSuchFeld_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (StationsSuchFeld.Text.Length < 1 && favorisierteStationen.Length > 1)
            {
                StationsNamensListe.ItemsSource = favorisierteStationen.Split('\n');
                return;
            }

            StationsNamensListe.ItemsSource = alleStationen
            .Where(station => station.name.Contains(StationsSuchFeld.Text, StringComparison.OrdinalIgnoreCase))
            .Select(station => station.name);
        }

        private void StationsNamensListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = StationsNamensListe.SelectedItem;
            if (selectedItem == null)
            {
                TafelOptionen.Visibility = Visibility.Collapsed;
                return;
            }
            
            var stationsname = selectedItem.ToString();
            if (stationsname == null) return;
            
            var kuerzel = alleStationen
            .FirstOrDefault(item => item.name.Equals(stationsname, StringComparison.OrdinalIgnoreCase)).acronym.ToString();


            var uriBuilder = new UriBuilder("https://meine.oebb.at/webdisplay/")
            {
                Query = $"stationId={kuerzel}&contentType=departure&staticLayout=true"
            };
            Uri stationsUri = uriBuilder.Uri;
            TafelVorschau.Source = stationsUri;

            FavorisiertSymbol.Glyph = "\uEB51";

            foreach (string station in favorisierteStationen.Split('\n'))
            {
                if (stationsname.Equals(station))
                {
                    FavorisiertSymbol.Glyph = "\uEB52";
                    break;
                }
            }

            TafelOptionen.Visibility = Visibility.Visible;
        }

        private void Favorisieren_Click(object sender, RoutedEventArgs e)
        {
            string? stationsAuswahl = StationsNamensListe.SelectedItem.ToString();
            if (stationsAuswahl == null) return;

            bool bereitsFavorisiert = false;

            foreach (string station in favorisierteStationen.Split('\n'))
            {
                if (stationsAuswahl.Equals(station))
                {
                    bereitsFavorisiert = true;
                    break;
                }
            }

            if (bereitsFavorisiert) // Eintrag l�schen
            {
                favorisierteStationen = favorisierteStationen.Replace(stationsAuswahl, "").Replace("\n\n", "\n");
                FavorisiertSymbol.Glyph = "\uEB51";
            }
            else
            {
                FavorisiertSymbol.Glyph = "\uEB52";

                if (favorisierteStationen.Length > 1)
                    favorisierteStationen += '\n';

                favorisierteStationen += stationsAuswahl;
            }
            einstellungen.Values.Clear();
            einstellungen.Values[favoritenSchluessel] = favorisierteStationen;
        }
    }
}
// favoriten sollen im appdata gespeichert werden
// bei appstart werden die favoriten angezeigt und auch immer dann, wenn das suchfeld leer ist
// wenn keine favoriten vorhanden sind, soll standardm��ig die gesamtliste geladen werden
// wenn favorisiert, dann ausgef�lltes appicon, wenn nicht dann ein nichtausgef�lltes 