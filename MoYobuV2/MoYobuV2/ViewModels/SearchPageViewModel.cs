using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using FFImageLoading;
using FFImageLoading.Forms;
using MangaDex.Client;
using MangaDex.Client.Dtos;
using MangaDex.Client.Filter;
using MangaDex.Client.Helpers;
using MoYobuV2.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Xamarin.Forms;

namespace MoYobuV2.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        #region Fileds

        #region Toolbar

        private bool _isLabelVisible = true;
        private bool _isBtnSearchVisible = true;
        private bool _isBtnBackVisible = false;
        private bool _isSearchBarVisible = false;

        #endregion

        #region Filter

        private string _title;

        // Original language
        private bool _originalLanguageJapanese;
        private bool _originalLanguageKorean;
        private bool _originalLanguageChinese;

        // Demographic
        private bool _demographicNone;
        private bool _demographicShounen;
        private bool _demographicShoujo;
        private bool _demographicSeinen;
        private bool _demographicJosei;

        // Content Rating
        private bool _contentRatingSafe;
        private bool _contentRatingSuggestive;
        private bool _contentRatingErotica;
        private bool _contentRatingPornographic;

        // Status
        private bool _statusOngoing;
        private bool _statusCompleted;
        private bool _statusHiatus;
        private bool _statusAbandoned;

        // Tags mode
        private string _includeTagMode;
        private string _excludeTagMode;

        // Tags
        private bool? _tagAction = false;
        private bool? _tagAdaptation = false;
        private bool? _tagAdventure = false;
        private bool? _tagAliens = false;
        private bool? _tagAnimals = false;
        private bool? _tagAnthology = false;
        private bool? _tagAwardWinning = false;
        private bool? _tagBoysLove = false;
        private bool? _tagComedy = false;
        private bool? _tagCooking = false;
        private bool? _tagCrime = false;
        private bool? _tagCrossdressing = false;
        private bool? _tagDelinquents = false;
        private bool? _tagDemons = false;
        private bool? _tagDoujinshi = false;
        private bool? _tagDrama = false;
        private bool? _tagFanColored = false;
        private bool? _tagFantasy = false;
        private bool? _tag4Koma = false;
        private bool? _tagFullColor = false;
        private bool? _tagGenderswap = false;
        private bool? _tagGhosts = false;
        private bool? _tagGirlsLove = false;
        private bool? _tagGore = false;
        private bool? _tagGyaru = false;
        private bool? _tagHarem = false;
        private bool? _tagHistorical = false;
        private bool? _tagHorror = false;
        private bool? _tagIncest = false;
        private bool? _tagIsekai = false;
        private bool? _tagLoli = false;
        private bool? _tagLongStrip = false;
        private bool? _tagMafia = false;
        private bool? _tagMagic = false;
        private bool? _tagMagicalGirls = false;
        private bool? _tagMartialArts = false;
        private bool? _tagMecha = false;
        private bool? _tagMedical = false;
        private bool? _tagMilitary = false;
        private bool? _tagMonsterGirls = false;
        private bool? _tagMonsters = false;
        private bool? _tagMusic = false;
        private bool? _tagMystery = false;
        private bool? _tagNinja = false;
        private bool? _tagOfficeWorkers = false;
        private bool? _tagOfficialColored = false;
        private bool? _tagOneshot = false;
        private bool? _tagPhilosophical = false;
        private bool? _tagPolice = false;
        private bool? _tagPostApocalyptic = false;
        private bool? _tagPsychological = false;
        private bool? _tagReincarnation = false;
        private bool? _tagReverseHarem = false;
        private bool? _tagRomance = false;
        private bool? _tagSamurai = false;
        private bool? _tagSchoolLife = false;
        private bool? _tagSciFi = false;
        private bool? _tagSexualViolence = false;
        private bool? _tagShota = false;
        private bool? _tagSliceofLife = false;
        private bool? _tagSports = false;
        private bool? _tagSuperhero = false;
        private bool? _tagSupernatural = false;
        private bool? _tagSurvival = false;
        private bool? _tagThriller = false;
        private bool? _tagTimeTravel = false;
        private bool? _tagTragedy = false;
        private bool? _tagTraditionalGames = false;
        private bool? _tagUserCreated = false;
        private bool? _tagVampires = false;
        private bool? _tagVideoGames = false;
        private bool? _tagVillainess = false;
        private bool? _tagVirtualReality = false;
        private bool? _tagWebComic = false;
        private bool? _tagWuxia = false;
        private bool? _tagZombies = false;

        #endregion

        #endregion

        #region Properties

        #region Toolbar

        public bool IsBtnSearchVisible
        {
            get { return _isBtnSearchVisible; }
            set => SetProperty(ref _isBtnSearchVisible, value);
        }

        public bool IsBtnBackVisible
        {
            get { return _isBtnBackVisible; }
            set => SetProperty(ref _isBtnBackVisible, value);
        }

        public bool IsSearchBarVisible
        {
            get { return _isSearchBarVisible; }
            set => SetProperty(ref _isSearchBarVisible, value);
        }

        public bool IsLabelVisible
        {
            get { return _isLabelVisible; }
            set => SetProperty(ref _isLabelVisible, value);
        }

        #endregion

        #region Filter

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title,
                value,
                nameof(Title),
                () => { Filter.Title = value; });
        }

        #region Original language

        public bool OriginalLanguageJapanese
        {
            get { return _originalLanguageJapanese; }
            set => SetProperty(ref _originalLanguageJapanese,
                value,
                nameof(OriginalLanguageJapanese),
                () => { Filter.OriginalLanguageJapanese = value; });
        }

        public bool OriginalLanguageKorean
        {
            get { return _originalLanguageKorean; }
            set => SetProperty(ref _originalLanguageKorean, value,
                nameof(OriginalLanguageKorean),
                () => { Filter.OriginalLanguageKorean = value; });
        }

        public bool OriginalLanguageChinese
        {
            get { return _originalLanguageChinese; }
            set => SetProperty(ref _originalLanguageChinese, value,
                nameof(OriginalLanguageChinese),
                () => { Filter.OriginalLanguageChinese = value; });
        }

        #endregion

        #region Demographic

        public bool DemographicNone
        {
            get { return _demographicNone; }
            set => SetProperty(ref _demographicNone, value,
                nameof(DemographicNone),
                () => { Filter.DemographicNone = value; });
        }

        public bool DemographicShounen
        {
            get { return _demographicShounen; }
            set => SetProperty(ref _demographicShounen, value,
                nameof(DemographicShounen),
                () => { Filter.DemographicShounen = value; });
        }

        public bool DemographicShoujo
        {
            get { return _demographicShoujo; }
            set => SetProperty(ref _demographicShoujo, value,
                nameof(DemographicShoujo),
                () => { Filter.DemographicShoujo = value; });
        }

        public bool DemographicSeinen
        {
            get { return _demographicSeinen; }
            set => SetProperty(ref _demographicSeinen, value,
                nameof(DemographicSeinen),
                () => { Filter.DemographicSeinen = value; });
        }

        public bool DemographicJosei
        {
            get { return _demographicJosei; }
            set => SetProperty(ref _demographicJosei, value,
                nameof(DemographicJosei),
                () => { Filter.DemographicJosei = value; });
        }

        #endregion

        #region Content Rating

        public bool ContentRatingSafe
        {
            get { return _contentRatingSafe; }
            set => SetProperty(ref _contentRatingSafe, value,
                nameof(ContentRatingSafe),
                () => { Filter.ContentRatingSafe = value; });
        }

        public bool ContentRatingSuggestive
        {
            get { return _contentRatingSuggestive; }
            set => SetProperty(ref _contentRatingSuggestive, value,
                nameof(ContentRatingSuggestive),
                () => { Filter.ContentRatingSuggestive = value; });
        }

        public bool ContentRatingErotica
        {
            get { return _contentRatingErotica; }
            set => SetProperty(ref _contentRatingErotica, value,
                nameof(ContentRatingErotica),
                () => { Filter.ContentRatingErotica = value; });
        }

        public bool ContentRatingPornographic
        {
            get { return _contentRatingPornographic; }
            set => SetProperty(ref _contentRatingPornographic, value,
                nameof(ContentRatingPornographic),
                () => { Filter.ContentRatingPornohraphy = value; });
        }

        #endregion

        #region Status

        public bool StatusOngoing
        {
            get { return _statusOngoing; }
            set => SetProperty(ref _statusOngoing, value,
                nameof(StatusOngoing),
                () => { Filter.StatusOngoing = value; });
        }

        public bool StatusCompleted
        {
            get { return _statusCompleted; }
            set => SetProperty(ref _statusCompleted, value,
                nameof(StatusCompleted),
                () => { Filter.StatusCompleted = value; });
        }

        public bool StatusHiatus
        {
            get { return _statusHiatus; }
            set => SetProperty(ref _statusHiatus, value,
                nameof(StatusHiatus),
                () => { Filter.StatusHiatus = value; });
        }

        public bool StatusAbandoned
        {
            get { return _statusAbandoned; }
            set => SetProperty(ref _statusAbandoned, value,
                nameof(StatusAbandoned),
                () => { Filter.StatusAbandoned = value; });
        }

        #endregion

        #region Tags mode

        public string IncludeTagMode
        {
            get { return _includeTagMode; }
            set => SetProperty(ref _includeTagMode, value,
                nameof(IncludeTagMode),
                () => { Filter.IncludeTagMode = value.ToLower().Equals("and") ? TagMode.And : TagMode.Or; });
        }

        public string ExcludeTagMode
        {
            get { return _excludeTagMode; }
            set => SetProperty(ref _excludeTagMode, value,
                nameof(ExcludeTagMode),
                () => { Filter.ExcludeTagMode = value.ToLower().Equals("and") ? TagMode.And : TagMode.Or; });
        }

        #endregion

        #region Tags

        public bool? TagAction
        {
            get { return _tagAction; }
            set => SetProperty(ref _tagAction, value,
                nameof(TagAction),
                () => { Filter.TagAction = value; });
        }

        public bool? TagAdaptation
        {
            get { return _tagAdaptation; }
            set => SetProperty(ref _tagAdaptation, value,
                nameof(TagAdaptation),
                () => { Filter.TagAdaptation = value; });
        }

        public bool? TagAdventure
        {
            get { return _tagAdventure; }
            set => SetProperty(ref _tagAdventure, value,
                nameof(TagAdventure),
                () => { Filter.TagAdventure = value; });
        }

        public bool? TagAliens
        {
            get { return _tagAliens; }
            set => SetProperty(ref _tagAliens, value,
                nameof(TagAliens),
                () => { Filter.TagAliens = value; });
        }

        public bool? TagAnimals
        {
            get { return _tagAnimals; }
            set => SetProperty(ref _tagAnimals, value,
                nameof(TagAnimals),
                () => { Filter.TagAnimals = value; });
        }

        public bool? TagAnthology
        {
            get { return _tagAnthology; }
            set => SetProperty(ref _tagAnthology, value,
                nameof(TagAnthology),
                () => { Filter.TagAnthology = value; });
        }

        public bool? TagAwardWinning
        {
            get { return _tagAwardWinning; }
            set => SetProperty(ref _tagAwardWinning, value,
                nameof(TagAwardWinning),
                () => { Filter.TagAwardWinning = value; });
        }

        public bool? TagBoysLove
        {
            get { return _tagBoysLove; }
            set => SetProperty(ref _tagBoysLove, value,
                nameof(TagBoysLove),
                () => { Filter.TagBoysLove = value; });
        }

        public bool? TagComedy
        {
            get { return _tagComedy; }
            set => SetProperty(ref _tagComedy, value,
                nameof(TagComedy),
                () => { Filter.TagComedy = value; });
        }

        public bool? TagCooking
        {
            get { return _tagCooking; }
            set => SetProperty(ref _tagCooking, value,
                nameof(TagCooking),
                () => { Filter.TagCooking = value; });
        }

        public bool? TagCrime
        {
            get { return _tagCrime; }
            set => SetProperty(ref _tagCrime, value,
                nameof(TagCrime),
                () => { Filter.TagCrime = value; });
        }

        public bool? TagCrossdressing
        {
            get { return _tagCrossdressing; }
            set => SetProperty(ref _tagCrossdressing, value,
                nameof(TagCrossdressing),
                () => { Filter.TagCrossdressing = value; });
        }

        public bool? TagDelinquents
        {
            get { return _tagDelinquents; }
            set => SetProperty(ref _tagDelinquents, value,
                nameof(TagDelinquents),
                () => { Filter.TagDelinquents = value; });
        }

        public bool? TagDemons
        {
            get { return _tagDemons; }
            set => SetProperty(ref _tagDemons, value,
                nameof(TagDemons),
                () => { Filter.TagDemons = value; });
        }

        public bool? TagDoujinshi
        {
            get { return _tagDoujinshi; }
            set => SetProperty(ref _tagDoujinshi, value,
                nameof(TagDoujinshi),
                () => { Filter.TagDoujinshi = value; });
        }

        public bool? TagDrama
        {
            get { return _tagDrama; }
            set => SetProperty(ref _tagDrama, value,
                nameof(TagDrama),
                () => { Filter.TagDrama = value; });
        }

        public bool? TagFanColored
        {
            get { return _tagFanColored; }
            set => SetProperty(ref _tagFanColored, value,
                nameof(TagFanColored),
                () => { Filter.TagFanColored = value; });
        }

        public bool? TagFantasy
        {
            get { return _tagFantasy; }
            set => SetProperty(ref _tagFantasy, value,
                nameof(TagFantasy),
                () => { Filter.TagFantasy = value; });
        }

        public bool? Tag4Koma
        {
            get { return _tag4Koma; }
            set => SetProperty(ref _tag4Koma, value,
                nameof(Tag4Koma),
                () => { Filter.Tag4Koma = value; });
        }

        public bool? TagFullColor
        {
            get { return _tagFullColor; }
            set => SetProperty(ref _tagFullColor, value,
                nameof(TagFullColor),
                () => { Filter.TagFullColor = value; });
        }

        public bool? TagGenderswap
        {
            get { return _tagGenderswap; }
            set => SetProperty(ref _tagGenderswap, value,
                nameof(TagGenderswap),
                () => { Filter.TagGenderswap = value; });
        }

        public bool? TagGhosts
        {
            get { return _tagGhosts; }
            set => SetProperty(ref _tagGhosts, value,
                nameof(TagGhosts),
                () => { Filter.TagGhosts = value; });
        }

        public bool? TagGirlsLove
        {
            get { return _tagGirlsLove; }
            set => SetProperty(ref _tagGirlsLove, value,
                nameof(TagGirlsLove),
                () => { Filter.TagGirlsLove = value; });
        }

        public bool? TagGore
        {
            get { return _tagGore; }
            set => SetProperty(ref _tagGore, value,
                nameof(TagGore),
                () => { Filter.TagGore = value; });
        }

        public bool? TagGyaru
        {
            get { return _tagGyaru; }
            set => SetProperty(ref _tagGyaru, value,
                nameof(TagGyaru),
                () => { Filter.TagGyaru = value; });
        }

        public bool? TagHarem
        {
            get { return _tagHarem; }
            set => SetProperty(ref _tagHarem, value,
                nameof(TagHarem),
                () => { Filter.TagHarem = value; });
        }

        public bool? TagHistorical
        {
            get { return _tagHistorical; }
            set => SetProperty(ref _tagHistorical, value,
                nameof(TagHistorical),
                () => { Filter.TagHistorical = value; });
        }

        public bool? TagHorror
        {
            get { return _tagHorror; }
            set => SetProperty(ref _tagHorror, value,
                nameof(TagHorror),
                () => { Filter.TagHorror = value; });
        }

        public bool? TagIncest
        {
            get { return _tagIncest; }
            set => SetProperty(ref _tagIncest, value,
                nameof(TagIncest),
                () => { Filter.TagIncest = value; });
        }

        public bool? TagIsekai
        {
            get { return _tagIsekai; }
            set => SetProperty(ref _tagIsekai, value,
                nameof(TagIsekai),
                () => { Filter.TagIsekai = value; });
        }

        public bool? TagLoli
        {
            get { return _tagLoli; }
            set => SetProperty(ref _tagLoli, value,
                nameof(TagLoli),
                () => { Filter.TagLoli = value; });
        }

        public bool? TagLongStrip
        {
            get { return _tagLongStrip; }
            set => SetProperty(ref _tagLongStrip, value,
                nameof(TagLongStrip),
                () => { Filter.TagLongStrip = value; });
        }

        public bool? TagMafia
        {
            get { return _tagMafia; }
            set => SetProperty(ref _tagMafia, value,
                nameof(TagMafia),
                () => { Filter.TagMafia = value; });
        }

        public bool? TagMagic
        {
            get { return _tagMagic; }
            set => SetProperty(ref _tagMagic, value,
                nameof(TagMagic),
                () => { Filter.TagMagic = value; });
        }

        public bool? TagMagicalGirls
        {
            get { return _tagMagicalGirls; }
            set => SetProperty(ref _tagMagicalGirls, value,
                nameof(TagMagicalGirls),
                () => { Filter.TagMagicalGirls = value; });
        }

        public bool? TagMartialArts
        {
            get { return _tagMartialArts; }
            set => SetProperty(ref _tagMartialArts, value,
                nameof(TagMartialArts),
                () => { Filter.TagMartialArts = value; });
        }

        public bool? TagMecha
        {
            get { return _tagMecha; }
            set => SetProperty(ref _tagMecha, value,
                nameof(TagMecha),
                () => { Filter.TagMecha = value; });
        }

        public bool? TagMedical
        {
            get { return _tagMedical; }
            set => SetProperty(ref _tagMedical, value,
                nameof(TagMedical),
                () => { Filter.TagMedical = value; });
        }

        public bool? TagMilitary
        {
            get { return _tagMilitary; }
            set => SetProperty(ref _tagMilitary, value,
                nameof(TagMilitary),
                () => { Filter.TagMilitary = value; });
        }

        public bool? TagMonsterGirls
        {
            get { return _tagMonsterGirls; }
            set => SetProperty(ref _tagMonsterGirls, value,
                nameof(TagMonsterGirls),
                () => { Filter.TagMonsterGirls = value; });
        }

        public bool? TagMonsters
        {
            get { return _tagMonsters; }
            set => SetProperty(ref _tagMonsters, value,
                nameof(TagMonsters),
                () => { Filter.TagMonsters = value; });
        }

        public bool? TagMusic
        {
            get { return _tagMusic; }
            set => SetProperty(ref _tagMusic, value,
                nameof(TagMusic),
                () => { Filter.TagMusic = value; });
        }

        public bool? TagMystery
        {
            get { return _tagMystery; }
            set => SetProperty(ref _tagMystery, value,
                nameof(TagMystery),
                () => { Filter.TagMystery = value; });
        }

        public bool? TagNinja
        {
            get { return _tagNinja; }
            set => SetProperty(ref _tagNinja, value,
                nameof(TagNinja),
                () => { Filter.TagNinja = value; });
        }

        public bool? TagOfficeWorkers
        {
            get { return _tagOfficeWorkers; }
            set => SetProperty(ref _tagOfficeWorkers, value,
                nameof(TagOfficeWorkers),
                () => { Filter.TagOfficeWorkers = value; });
        }

        public bool? TagOfficialColored
        {
            get { return _tagOfficialColored; }
            set => SetProperty(ref _tagOfficialColored, value,
                nameof(TagOfficialColored),
                () => { Filter.TagOfficialColored = value; });
        }

        public bool? TagOneshot
        {
            get { return _tagOneshot; }
            set => SetProperty(ref _tagOneshot, value,
                nameof(TagOneshot),
                () => { Filter.TagOneshot = value; });
        }

        public bool? TagPhilosophical
        {
            get { return _tagPhilosophical; }
            set => SetProperty(ref _tagPhilosophical, value,
                nameof(TagPhilosophical),
                () => { Filter.TagPhilosophical = value; });
        }

        public bool? TagPolice
        {
            get { return _tagPolice; }
            set => SetProperty(ref _tagPolice, value,
                nameof(TagPolice),
                () => { Filter.TagPolice = value; });
        }

        public bool? TagPostApocalyptic
        {
            get { return _tagPostApocalyptic; }
            set => SetProperty(ref _tagPostApocalyptic, value,
                nameof(TagPostApocalyptic),
                () => { Filter.TagPostApocalyptic = value; });
        }

        public bool? TagPsychological
        {
            get { return _tagPsychological; }
            set => SetProperty(ref _tagPsychological, value,
                nameof(TagPsychological),
                () => { Filter.TagPsychological = value; });
        }

        public bool? TagReincarnation
        {
            get { return _tagReincarnation; }
            set => SetProperty(ref _tagReincarnation, value,
                nameof(TagReincarnation),
                () => { Filter.TagReincarnation = value; });
        }

        public bool? TagReverseHarem
        {
            get { return _tagReverseHarem; }
            set => SetProperty(ref _tagReverseHarem, value,
                nameof(TagReverseHarem),
                () => { Filter.TagReverseHarem = value; });
        }

        public bool? TagRomance
        {
            get { return _tagRomance; }
            set => SetProperty(ref _tagRomance, value,
                nameof(TagRomance),
                () => { Filter.TagRomance = value; });
        }

        public bool? TagSamurai
        {
            get { return _tagSamurai; }
            set => SetProperty(ref _tagSamurai, value,
                nameof(TagSamurai),
                () => { Filter.TagSamurai = value; });
        }

        public bool? TagSchoolLife
        {
            get { return _tagSchoolLife; }
            set => SetProperty(ref _tagSchoolLife, value,
                nameof(TagSchoolLife),
                () => { Filter.TagSchoolLife = value; });
        }

        public bool? TagSciFi
        {
            get { return _tagSciFi; }
            set => SetProperty(ref _tagSciFi, value,
                nameof(TagSciFi),
                () => { Filter.TagSciFi = value; });
        }

        public bool? TagSexualViolence
        {
            get { return _tagSexualViolence; }
            set => SetProperty(ref _tagSexualViolence, value,
                nameof(TagSexualViolence),
                () => { Filter.TagSexualViolence = value; });
        }

        public bool? TagShota
        {
            get { return _tagShota; }
            set => SetProperty(ref _tagShota, value,
                nameof(TagShota),
                () => { Filter.TagShota = value; });
        }

        public bool? TagSliceofLife
        {
            get { return _tagSliceofLife; }
            set => SetProperty(ref _tagSliceofLife, value,
                nameof(TagSliceofLife),
                () => { Filter.TagSliceofLife = value; });
        }

        public bool? TagSports
        {
            get { return _tagSports; }
            set => SetProperty(ref _tagSports, value,
                nameof(TagSports),
                () => { Filter.TagSports = value; });
        }

        public bool? TagSuperhero
        {
            get { return _tagSuperhero; }
            set => SetProperty(ref _tagSuperhero, value,
                nameof(TagSuperhero),
                () => { Filter.TagSuperhero = value; });
        }

        public bool? TagSupernatural
        {
            get { return _tagSupernatural; }
            set => SetProperty(ref _tagSupernatural, value,
                nameof(TagSupernatural),
                () => { Filter.TagSupernatural = value; });
        }

        public bool? TagSurvival
        {
            get { return _tagSurvival; }
            set => SetProperty(ref _tagSurvival, value,
                nameof(TagSurvival),
                () => { Filter.TagSurvival = value; });
        }

        public bool? TagThriller
        {
            get { return _tagThriller; }
            set => SetProperty(ref _tagThriller, value,
                nameof(TagThriller),
                () => { Filter.TagThriller = value; });
        }

        public bool? TagTimeTravel
        {
            get { return _tagTimeTravel; }
            set => SetProperty(ref _tagTimeTravel, value,
                nameof(TagTimeTravel),
                () => { Filter.TagTimeTravel = value; });
        }

        public bool? TagTragedy
        {
            get { return _tagTragedy; }
            set => SetProperty(ref _tagTragedy, value,
                nameof(TagTragedy),
                () => { Filter.TagTragedy = value; });
        }

        public bool? TagTraditionalGames
        {
            get { return _tagTraditionalGames; }
            set => SetProperty(ref _tagTraditionalGames, value,
                nameof(TagTraditionalGames),
                () => { Filter.TagTraditionalGames = value; });
        }

        public bool? TagUserCreated
        {
            get { return _tagUserCreated; }
            set => SetProperty(ref _tagUserCreated, value,
                nameof(TagUserCreated),
                () => { Filter.TagUserCreated = value; });
        }

        public bool? TagVampires
        {
            get { return _tagVampires; }
            set => SetProperty(ref _tagVampires, value,
                nameof(TagVampires),
                () => { Filter.TagVampires = value; });
        }

        public bool? TagVideoGames
        {
            get { return _tagVideoGames; }
            set => SetProperty(ref _tagVideoGames, value,
                nameof(TagVideoGames),
                () => { Filter.TagVideoGames = value; });
        }

        public bool? TagVillainess
        {
            get { return _tagVillainess; }
            set => SetProperty(ref _tagVillainess, value,
                nameof(TagVillainess),
                () => { Filter.TagVillainess = value; });
        }

        public bool? TagVirtualReality
        {
            get { return _tagVirtualReality; }
            set => SetProperty(ref _tagVirtualReality, value,
                nameof(TagVirtualReality),
                () => { Filter.TagVirtualReality = value; });
        }

        public bool? TagWebComic
        {
            get { return _tagWebComic; }
            set => SetProperty(ref _tagWebComic, value,
                nameof(TagWebComic),
                () => { Filter.TagWebComic = value; });
        }

        public bool? TagWuxia
        {
            get { return _tagWuxia; }
            set => SetProperty(ref _tagWuxia, value,
                nameof(TagWuxia),
                () => { Filter.TagWuxia = value; });
        }

        public bool? TagZombies
        {
            get { return _tagZombies; }
            set => SetProperty(ref _tagZombies, value,
                nameof(TagZombies),
                () => { Filter.TagZombies = value; });
        }

        #endregion

        #endregion

        #endregion

        public ObservableRangeCollection<MangaDto> MangaList { get; set; }
        public MdMangaFilter Filter { get; set; }
        public MdClient MdClient { get; set; }

        public int Offset { get; set; } = 0;

        // private HttpClient _http = null;

        public ICommand LoadMoreCommand { get; }
        // private SearchPage _searchPage;

        public SearchPageViewModel()
        {
            // if(_http == null)
            // {
            //     HttpClientHandler handler = new HttpClientHandler()
            //     {
            //         AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            //     };        
            //     _http = new HttpClient(handler);
            // }
            //
            // var config = new FFImageLoading.Config.Configuration()
            // {
            //     ExecuteCallbacksOnUIThread = true,
            //     HttpClient = _http,
            //
            // };
            // ImageService.Instance.Initialize(config);

            // CachedImage c = new CachedImage();

            // c.Source = ImageSource.FromUri();


            MdClient = new MdClient();
            MangaList = new ObservableRangeCollection<MangaDto>();
            Filter = new MdMangaFilter();
            LoadMoreCommand = new AsyncCommand<object>(LoadMore);
        }

        public async Task LoadMore(object obj)
        {
            if (IsBusy)
                return;

            var listView = obj as Syncfusion.ListView.XForms.SfListView;

            IsBusy = true;
            listView.IsBusy = true;
            Filter.Offset = Offset;
            Offset += Filter.Limit;
            var data = await MdClient.SearchManga(Filter.Build());

            Debug.WriteLine($"Filter offset: {Filter.Offset} - _offest: {Offset}");

            foreach (var item in data.Data)
            {
                // https://uploads.mangadex.org/covers/{ manga.id }/{ cover.filename }.256.jpg
                var coverId = item.Relationships.First(x => x.Type == MdConstants.CoverArt).Id;
                // item.Attributes.Cover256 = $"{MdConstants.ApiCover256Url}/{item.Id}/{coverId}.256.jpg";
                var coverData = await MdClient.GetCover(coverId);
                // "https://uploads.mangadex.org/covers/95929ed7-6b14-4ce4-820c-3ece99eeccba/7dbca5f9-9fa1-4296-8315-9fd906814911.png.256.jpg";
                // string temp = $"{MdConstants.ApiCover256Url}/{item.Id}/{coverData.Data.Attributes.FileName}.256.jpg";
                item.Attributes.Cover256 =
                    $"{MdConstants.ApiCover256Url}/{item.Id}/{coverData.Data.Attributes.FileName}.256.jpg";
                item.Attributes.Cover256Uri = new Uri(item.Attributes.Cover256);

                string tempUri = item.Attributes.Cover256;

                // get cover filenam by cover id
            }

            MangaList.AddRange(data.Data);

            IsBusy = false;
            listView.IsBusy = false;
        }

        public async Task LoadFirst()
        {
            if (IsBusy)
                return;

            // var listView = obj as Syncfusion.ListView.XForms.SfListView;

            IsBusy = true;
            // listView.IsBusy = true;
            Filter.Offset = Offset;
            Offset += Filter.Limit;
            var data = await MdClient.SearchManga(Filter.Build());

            Debug.WriteLine($"Filter offset: {Filter.Offset} - _offest: {Offset}");

            foreach (var item in data.Data)
            {
                // https://uploads.mangadex.org/covers/{ manga.id }/{ cover.filename }.256.jpg
                var coverId = item.Relationships.First(x => x.Type == MdConstants.CoverArt).Id;
                // item.Attributes.Cover256 = $"{MdConstants.ApiCover256Url}/{item.Id}/{coverId}.256.jpg";
                var coverData = await MdClient.GetCover(coverId);
                item.Attributes.Cover256 =
                    $"{MdConstants.ApiCover256Url}/{item.Id}/{coverData.Data.Attributes.FileName}.256.jpg";

                // get cover filenam by cover id
            }

            MangaList.AddRange(data.Data);

            IsBusy = false;
            // listView.IsBusy = true;
        }

        // public async Task LoadData(int offset = 0)
        // {
        //     Filter.Offset = offset;
        //     var data = await MdClient.SearchManga(Filter.Build());
        //
        //     foreach (var item in data.Data)
        //     {
        //         // https://uploads.mangadex.org/covers/{ manga.id }/{ cover.filename }.256.jpg
        //         var coverId = item.Relationships.First(x => x.Type == MdConstants.CoverArt).Id;
        //         // item.Attributes.Cover256 = $"{MdConstants.ApiCover256Url}/{item.Id}/{coverId}.256.jpg";
        //         var coverData = await MdClient.GetCover(coverId);
        //         item.Attributes.Cover256 = $"{MdConstants.ApiCover256Url}/{item.Id}/{coverData.Data.Attributes.FileName}.256.jpg";
        //
        //         // get cover filenam by cover id
        //     }
        //     
        //     MangaList.AddRange(data.Data);
        //
        //     // var t = "";
        // }

        public void TestData()
        {
            for (int i = 1; i <= 14; i++)
            {
                // MangaList.Add(new Manga("Manga title", ImageSource.FromResource($"MoYobuV2.Images.{i}.png")));
            }
        }
    }
}