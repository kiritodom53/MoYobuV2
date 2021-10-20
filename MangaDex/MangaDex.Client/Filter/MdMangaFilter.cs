using System;
using System.Collections.Generic;
using System.Linq;
using MangaDex.Client.Helpers;

namespace MangaDex.Client.Filter
{
    public class MdMangaFilter : MdCollectionFilter
    {
        // Todo: Ve viewModel bude UI filter a když třeba check box změní, tak
        // Todo: se při NotifyPropertyChange změní filter a před hledáním
        // Todo: se znovu sestaví a vytvoří url parametrů

        // Todo: pokud je Demographic vše true není potřeba zadávat
        // Todo: shared preferences - default filter

        private QueryParameters _parametersParams;

        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 25;

        #region Properties

        public string Title { get; set; }

        #region Original Language

        public bool OriginalLanguageJapanese { get; set; }
        public bool OriginalLanguageKorean { get; set; }
        public bool OriginalLanguageChinese { get; set; }

        #endregion

        #region Demographic

        public bool DemographicShounen { get; set; } = false;
        public bool DemographicShoujo { get; set; } = false;
        public bool DemographicSeinen { get; set; } = false;
        public bool DemographicJosei { get; set; } = false;
        public bool DemographicNone { get; set; } = false;

        #endregion

        #region Content Rating

        public bool ContentRatingSafe { get; set; }
        public bool ContentRatingSuggestive { get; set; }
        public bool ContentRatingErotica { get; set; }
        public bool ContentRatingPornohraphy { get; set; }

        #endregion

        #region Status

        public bool StatusOngoing { get; set; } = false;
        public bool StatusCompleted { get; set; } = false;
        public bool StatusHiatus { get; set; } = false;
        public bool StatusAbandoned { get; set; } = false;

        #endregion

        #region Tags mode

        public TagMode IncludeTagMode { get; set; } = TagMode.And;
        public TagMode ExcludeTagMode { get; set; } = TagMode.Or;

        #endregion

        #region Tags

        public bool? TagAction { get; set; } = false;
        public bool? TagAdaptation { get; set; } = false;
        public bool? TagAdventure { get; set; } = false;
        public bool? TagAliens { get; set; } = false;
        public bool? TagAnimals { get; set; } = false;
        public bool? TagAnthology { get; set; } = false;
        public bool? TagAwardWinning { get; set; } = false;
        public bool? TagBoysLove { get; set; } = false;
        public bool? TagComedy { get; set; } = false;
        public bool? TagCooking { get; set; } = false;
        public bool? TagCrime { get; set; } = false;
        public bool? TagCrossdressing { get; set; } = false;
        public bool? TagDelinquents { get; set; } = false;
        public bool? TagDemons { get; set; } = false;
        public bool? TagDoujinshi { get; set; } = false;
        public bool? TagDrama { get; set; } = false;
        public bool? TagFanColored { get; set; } = false;
        public bool? TagFantasy { get; set; } = false;
        public bool? Tag4Koma { get; set; } = false;
        public bool? TagFullColor { get; set; } = false;
        public bool? TagGenderswap { get; set; } = false;
        public bool? TagGhosts { get; set; } = false;
        public bool? TagGirlsLove { get; set; } = false;
        public bool? TagGore { get; set; } = false;
        public bool? TagGyaru { get; set; } = false;
        public bool? TagHarem { get; set; } = false;
        public bool? TagHistorical { get; set; } = false;
        public bool? TagHorror { get; set; } = false;
        public bool? TagIncest { get; set; } = false;
        public bool? TagIsekai { get; set; } = false;
        public bool? TagLoli { get; set; } = false;
        public bool? TagLongStrip { get; set; } = false;
        public bool? TagMafia { get; set; } = false;
        public bool? TagMagic { get; set; } = false;
        public bool? TagMagicalGirls { get; set; } = false;
        public bool? TagMartialArts { get; set; } = false;
        public bool? TagMecha { get; set; } = false;
        public bool? TagMedical { get; set; } = false;
        public bool? TagMilitary { get; set; } = false;
        public bool? TagMonsterGirls { get; set; } = false;
        public bool? TagMonsters { get; set; } = false;
        public bool? TagMusic { get; set; } = false;
        public bool? TagMystery { get; set; } = false;
        public bool? TagNinja { get; set; } = false;
        public bool? TagOfficeWorkers { get; set; } = false;
        public bool? TagOfficialColored { get; set; } = false;
        public bool? TagOneshot { get; set; } = false;
        public bool? TagPhilosophical { get; set; } = false;
        public bool? TagPolice { get; set; } = false;
        public bool? TagPostApocalyptic { get; set; } = false;
        public bool? TagPsychological { get; set; } = false;
        public bool? TagReincarnation { get; set; } = false;
        public bool? TagReverseHarem { get; set; } = false;
        public bool? TagRomance { get; set; } = false;
        public bool? TagSamurai { get; set; } = false;
        public bool? TagSchoolLife { get; set; } = false;
        public bool? TagSciFi { get; set; } = false;
        public bool? TagSexualViolence { get; set; } = false;
        public bool? TagShota { get; set; } = false;
        public bool? TagSliceofLife { get; set; } = false;
        public bool? TagSports { get; set; } = false;
        public bool? TagSuperhero { get; set; } = false;
        public bool? TagSupernatural { get; set; } = false;
        public bool? TagSurvival { get; set; } = false;
        public bool? TagThriller { get; set; } = false;
        public bool? TagTimeTravel { get; set; } = false;
        public bool? TagTragedy { get; set; } = false;
        public bool? TagTraditionalGames { get; set; } = false;
        public bool? TagUserCreated { get; set; } = false;
        public bool? TagVampires { get; set; } = false;
        public bool? TagVideoGames { get; set; } = false;
        public bool? TagVillainess { get; set; } = false;
        public bool? TagVirtualReality { get; set; } = false;
        public bool? TagWebComic { get; set; } = false;
        public bool? TagWuxia { get; set; } = false;
        public bool? TagZombies { get; set; } = false;

        #endregion

        #endregion

        #region Setters

        public MdMangaFilter SetTitle(string title)
        {
            Title = string.IsNullOrEmpty(title) ? string.Empty : title;
            return this;
        }


        #region Original Language

        public MdMangaFilter SetOriginalLanguageJapanese(bool value = true)
        {
            OriginalLanguageJapanese = value;
            return this;
        }

        public MdMangaFilter SetOriginalLanguageKorean(bool value = true)
        {
            OriginalLanguageKorean = value;
            return this;
        }

        public MdMangaFilter SetOriginalLanguageChinese(bool value = true)
        {
            OriginalLanguageChinese = value;
            return this;
        }

        #endregion

        #region Demographic

        public MdMangaFilter SetDemographicAll(bool value = true)
        {
            DemographicShounen = value;
            DemographicSeinen = value;
            DemographicShoujo = value;
            DemographicJosei = value;
            DemographicNone = value;
            return this;
        }

        public MdMangaFilter SetDemographicShounen(bool value = true)
        {
            DemographicShounen = value;
            return this;
        }

        public MdMangaFilter SetDemographicSeinen(bool value = true)
        {
            DemographicSeinen = value;
            return this;
        }

        public MdMangaFilter SetDemographicShoujo(bool value = true)
        {
            DemographicShoujo = value;
            return this;
        }

        public MdMangaFilter SetDemographicJosei(bool value = true)
        {
            DemographicJosei = value;
            return this;
        }

        public MdMangaFilter SetDemographicNone(bool value = true)
        {
            DemographicNone = value;
            return this;
        }

        #endregion

        #region Content Rating

        public MdMangaFilter SetContentRatingSafe(bool value = true)
        {
            ContentRatingSafe = value;
            return this;
        }

        public MdMangaFilter SetContentRatingSuggestive(bool value = true)
        {
            ContentRatingSuggestive = value;
            return this;
        }

        public MdMangaFilter SetContentRatingErotica(bool value = true)
        {
            ContentRatingErotica = value;
            return this;
        }

        public MdMangaFilter SetContentRatingPornographic(bool value = true)
        {
            ContentRatingPornohraphy = value;
            return this;
        }

        #endregion

        #region Status

        public MdMangaFilter SetStatusAll(bool value = true)
        {
            StatusOngoing = value;
            StatusCompleted = value;
            StatusHiatus = value;
            StatusAbandoned = value;
            return this;
        }

        public MdMangaFilter SetStatusOngoing(bool value = true)
        {
            StatusOngoing = value;
            return this;
        }

        public MdMangaFilter SetStatusCompleted(bool value = true)
        {
            StatusCompleted = value;
            return this;
        }

        public MdMangaFilter SetStatusHiatus(bool value = true)
        {
            StatusHiatus = value;
            return this;
        }

        public MdMangaFilter SetStatusAbandoned(bool value = true)
        {
            StatusAbandoned = value;
            return this;
        }

        #endregion

        #region Tags mode

        public MdMangaFilter SetIncludeTagsMode(TagMode mode = TagMode.And)
        {
            IncludeTagMode = mode;
            return this;
        }

        public MdMangaFilter SetExcludeTagsMode(TagMode mode = TagMode.Or)
        {
            ExcludeTagMode = mode;
            return this;
        }

        #endregion

        #region Tags

        public MdMangaFilter SetTagAction(bool? value = true)
        {
            TagAction = value;
            return this;
        }

        public MdMangaFilter SetTagAdaptation(bool? value = true)
        {
            TagAdaptation = value;
            return this;
        }

        public MdMangaFilter SetTagAdventure(bool? value = true)
        {
            TagAdventure = value;
            return this;
        }

        public MdMangaFilter SetTagAliens(bool? value = true)
        {
            TagAliens = value;
            return this;
        }

        public MdMangaFilter SetTagAnimals(bool? value = true)
        {
            TagAnimals = value;
            return this;
        }

        public MdMangaFilter SetTagAnthology(bool? value = true)
        {
            TagAnthology = value;
            return this;
        }

        public MdMangaFilter SetTagAwardWinning(bool? value = true)
        {
            TagAwardWinning = value;
            return this;
        }

        public MdMangaFilter SetTagBoysLove(bool? value = true)
        {
            TagBoysLove = value;
            return this;
        }

        public MdMangaFilter SetTagComedy(bool? value = true)
        {
            TagComedy = value;
            return this;
        }

        public MdMangaFilter SetTagCooking(bool? value = true)
        {
            TagCooking = value;
            return this;
        }

        public MdMangaFilter SetTagCrime(bool? value = true)
        {
            TagCrime = value;
            return this;
        }

        public MdMangaFilter SetTagCrossdressing(bool? value = true)
        {
            TagCrossdressing = value;
            return this;
        }

        public MdMangaFilter SetTagDelinquents(bool? value = true)
        {
            TagDelinquents = value;
            return this;
        }

        public MdMangaFilter SetTagDemons(bool? value = true)
        {
            TagDemons = value;
            return this;
        }

        public MdMangaFilter SetTagDoujinshi(bool? value = true)
        {
            TagDoujinshi = value;
            return this;
        }

        public MdMangaFilter SetTagDrama(bool? value = true)
        {
            TagDrama = value;
            return this;
        }

        public MdMangaFilter SetTagFanColored(bool? value = true)
        {
            TagFanColored = value;
            return this;
        }

        public MdMangaFilter SetTagFantasy(bool? value = true)
        {
            TagFantasy = value;
            return this;
        }

        public MdMangaFilter SetTag4Koma(bool? value = true)
        {
            Tag4Koma = value;
            return this;
        }

        public MdMangaFilter SetTagFullColor(bool? value = true)
        {
            TagFullColor = value;
            return this;
        }

        public MdMangaFilter SetTagGenderswap(bool? value = true)
        {
            TagGenderswap = value;
            return this;
        }

        public MdMangaFilter SetTagGhosts(bool? value = true)
        {
            TagGhosts = value;
            return this;
        }

        public MdMangaFilter SetTagGirlsLove(bool? value = true)
        {
            TagGirlsLove = value;
            return this;
        }

        public MdMangaFilter SetTagGore(bool? value = true)
        {
            TagGore = value;
            return this;
        }

        public MdMangaFilter SetTagGyaru(bool? value = true)
        {
            TagGyaru = value;
            return this;
        }

        public MdMangaFilter SetTagHarem(bool? value = true)
        {
            TagHarem = value;
            return this;
        }

        public MdMangaFilter SetTagHistorical(bool? value = true)
        {
            TagHistorical = value;
            return this;
        }

        public MdMangaFilter SetTagHorror(bool? value = true)
        {
            TagHorror = value;
            return this;
        }

        public MdMangaFilter SetTagIncest(bool? value = true)
        {
            TagIncest = value;
            return this;
        }

        public MdMangaFilter SetTagIsekai(bool? value = true)
        {
            TagIsekai = value;
            return this;
        }

        public MdMangaFilter SetTagLoli(bool? value = true)
        {
            TagLoli = value;
            return this;
        }

        public MdMangaFilter SetTagLongStrip(bool? value = true)
        {
            TagLongStrip = value;
            return this;
        }

        public MdMangaFilter SetTagMafia(bool? value = true)
        {
            TagMafia = value;
            return this;
        }

        public MdMangaFilter SetTagMagic(bool? value = true)
        {
            TagMagic = value;
            return this;
        }

        public MdMangaFilter SetTagMagicalGirls(bool? value = true)
        {
            TagMagicalGirls = value;
            return this;
        }

        public MdMangaFilter SetTagMartialArts(bool? value = true)
        {
            TagMartialArts = value;
            return this;
        }

        public MdMangaFilter SetTagMecha(bool? value = true)
        {
            TagMecha = value;
            return this;
        }

        public MdMangaFilter SetTagMedical(bool? value = true)
        {
            TagMedical = value;
            return this;
        }

        public MdMangaFilter SetTagMilitary(bool? value = true)
        {
            TagMilitary = value;
            return this;
        }

        public MdMangaFilter SetTagMonsterGirls(bool? value = true)
        {
            TagMonsterGirls = value;
            return this;
        }

        public MdMangaFilter SetTagMonsters(bool? value = true)
        {
            TagMonsters = value;
            return this;
        }

        public MdMangaFilter SetTagMusic(bool? value = true)
        {
            TagMusic = value;
            return this;
        }

        public MdMangaFilter SetTagMystery(bool? value = true)
        {
            TagMystery = value;
            return this;
        }

        public MdMangaFilter SetTagNinja(bool? value = true)
        {
            TagNinja = value;
            return this;
        }

        public MdMangaFilter SetTagOfficeWorkers(bool? value = true)
        {
            TagOfficeWorkers = value;
            return this;
        }

        public MdMangaFilter SetTagOfficialColored(bool? value = true)
        {
            TagOfficialColored = value;
            return this;
        }

        public MdMangaFilter SetTagOneshot(bool? value = true)
        {
            TagOneshot = value;
            return this;
        }

        public MdMangaFilter SetTagPhilosophical(bool? value = true)
        {
            TagPhilosophical = value;
            return this;
        }

        public MdMangaFilter SetTagPolice(bool? value = true)
        {
            TagPolice = value;
            return this;
        }

        public MdMangaFilter SetTagPostApocalyptic(bool? value = true)
        {
            TagPostApocalyptic = value;
            return this;
        }

        public MdMangaFilter SetTagPsychological(bool? value = true)
        {
            TagPsychological = value;
            return this;
        }

        public MdMangaFilter SetTagReincarnation(bool? value = true)
        {
            TagReincarnation = value;
            return this;
        }

        public MdMangaFilter SetTagReverseHarem(bool? value = true)
        {
            TagReverseHarem = value;
            return this;
        }

        public MdMangaFilter SetTagRomance(bool? value = true)
        {
            TagRomance = value;
            return this;
        }

        public MdMangaFilter SetTagSamurai(bool? value = true)
        {
            TagSamurai = value;
            return this;
        }

        public MdMangaFilter SetTagSchoolLife(bool? value = true)
        {
            TagSchoolLife = value;
            return this;
        }

        public MdMangaFilter SetTagSciFi(bool? value = true)
        {
            TagSciFi = value;
            return this;
        }

        public MdMangaFilter SetTagSexualViolence(bool? value = true)
        {
            TagSexualViolence = value;
            return this;
        }

        public MdMangaFilter SetTagShota(bool? value = true)
        {
            TagShota = value;
            return this;
        }

        public MdMangaFilter SetTagSliceofLife(bool? value = true)
        {
            TagSliceofLife = value;
            return this;
        }

        public MdMangaFilter SetTagSports(bool? value = true)
        {
            TagSports = value;
            return this;
        }

        public MdMangaFilter SetTagSuperhero(bool? value = true)
        {
            TagSuperhero = value;
            return this;
        }

        public MdMangaFilter SetTagSupernatural(bool? value = true)
        {
            TagSupernatural = value;
            return this;
        }

        public MdMangaFilter SetTagSurvival(bool? value = true)
        {
            TagSurvival = value;
            return this;
        }

        public MdMangaFilter SetTagThriller(bool? value = true)
        {
            TagThriller = value;
            return this;
        }

        public MdMangaFilter SetTagTimeTravel(bool? value = true)
        {
            TagTimeTravel = value;
            return this;
        }

        public MdMangaFilter SetTagTragedy(bool? value = true)
        {
            TagTragedy = value;
            return this;
        }

        public MdMangaFilter SetTagTraditionalGames(bool? value = true)
        {
            TagTraditionalGames = value;
            return this;
        }

        public MdMangaFilter SetTagUserCreated(bool? value = true)
        {
            TagUserCreated = value;
            return this;
        }

        public MdMangaFilter SetTagVampires(bool? value = true)
        {
            TagVampires = value;
            return this;
        }

        public MdMangaFilter SetTagVideoGames(bool? value = true)
        {
            TagVideoGames = value;
            return this;
        }

        public MdMangaFilter SetTagVillainess(bool? value = true)
        {
            TagVillainess = value;
            return this;
        }

        public MdMangaFilter SetTagVirtualReality(bool? value = true)
        {
            TagVirtualReality = value;
            return this;
        }

        public MdMangaFilter SetTagWebComic(bool? value = true)
        {
            TagWebComic = value;
            return this;
        }

        public MdMangaFilter SetTagWuxia(bool? value = true)
        {
            TagWuxia = value;
            return this;
        }

        public MdMangaFilter SetTagZombies(bool? value = true)
        {
            TagZombies = value;
            return this;
        }

        #endregion

        #endregion

        #region Build parts

        private void BuildTitle()
        {
            // if (!string.IsNullOrEmpty(Title))
            // _parametersParams.Add("title", Title);
            // _parametersParams.Add("title", "Grand Blue");
            // Todo: Remove
        }

        private void BuildOriginalLanguage()
        {
            if (Helper.IsBoolValuesSame(OriginalLanguageJapanese, OriginalLanguageKorean, OriginalLanguageChinese))
                return;

            if (OriginalLanguageJapanese)
                _parametersParams.Add("originalLanguage[]", "ja");
            if (OriginalLanguageKorean)
                _parametersParams.Add("originalLanguage[]", "ko");
            if (OriginalLanguageChinese)
            {
                _parametersParams.Add("originalLanguage[]", "zh");
                _parametersParams.Add("originalLanguage[]", "zh-hk");
            }
        }

        private void BuildDemographic()
        {
            // If any or not
            if (Helper.IsBoolValuesSame(DemographicShounen, DemographicShoujo, DemographicSeinen,
                DemographicJosei, DemographicNone))
                return;

            if (DemographicShounen)
                _parametersParams.Add("publicationDemographic[]", "shounen");
            if (DemographicShoujo)
                _parametersParams.Add("publicationDemographic[]", "seinen");
            if (DemographicSeinen)
                _parametersParams.Add("publicationDemographic[]", "shoujo");
            if (DemographicJosei)
                _parametersParams.Add("publicationDemographic[]", "josei");
            if (DemographicNone)
                _parametersParams.Add("publicationDemographic[]", "none");
        }

        private void BuldContentRating()
        {
            if (Helper.IsBoolValuesSame(ContentRatingSafe, ContentRatingSuggestive, ContentRatingErotica,
                ContentRatingPornohraphy))
                return;

            if (ContentRatingSafe)
                _parametersParams.Add("contentRating[]", "safe");
            if (ContentRatingSuggestive)
                _parametersParams.Add("contentRating[]", "suggestive");
            if (ContentRatingErotica)
                _parametersParams.Add("contentRating[]", "erotica");
            if (ContentRatingPornohraphy)
                _parametersParams.Add("contentRating[]", "pornographic");
        }

        private void BuildStatus()
        {
            // If any or not
            if (Helper.IsBoolValuesSame(StatusOngoing, StatusCompleted, StatusHiatus, StatusAbandoned))
                return;

            if (StatusOngoing)
                _parametersParams.Add("status[]", "ongoing");
            if (StatusCompleted)
                _parametersParams.Add("status[]", "completed");
            if (StatusHiatus)
                _parametersParams.Add("status[]", "hiatus");
            if (StatusAbandoned)
                _parametersParams.Add("status[]", "cancelled");
        }

        private void BuildTagModes()
        {
            if (IncludeTagMode == TagMode.Or)
                _parametersParams.Add("includedTagsMode", "OR");
            if (ExcludeTagMode == TagMode.And)
                _parametersParams.Add("excludedTagsMode", "AND");
        }

        private void BuildTags()
        {
            if (TagAction == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Action"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Action"));

            if (TagAdaptation == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Adaptation"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Adaptation"));

            if (TagAdventure == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Adventure"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Adventure"));

            if (TagAliens == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Aliens"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Aliens"));

            if (TagAnimals == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Animals"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Animals"));

            if (TagAnthology == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Anthology"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Anthology"));

            if (TagAwardWinning == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("AwardWinning"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("AwardWinning"));

            if (TagBoysLove == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("BoysLove"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("BoysLove"));

            if (TagComedy == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Comedy"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Comedy"));

            if (TagCooking == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Cooking"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Cooking"));

            if (TagCrime == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Crime"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Crime"));

            if (TagCrossdressing == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Crossdressing"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Crossdressing"));

            if (TagDelinquents == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Delinquents"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Delinquents"));

            if (TagDemons == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Demons"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Demons"));

            if (TagDoujinshi == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Doujinshi"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Doujinshi"));

            if (TagDrama == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Drama"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Drama"));

            if (TagFanColored == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("FanColored"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("FanColored"));

            if (TagFantasy == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Fantasy"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Fantasy"));

            if (Tag4Koma == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("4Koma"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("4Koma"));

            if (TagFullColor == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("FullColor"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("FullColor"));

            if (TagGenderswap == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Genderswap"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Genderswap"));

            if (TagGhosts == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Ghosts"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Ghosts"));

            if (TagGirlsLove == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("GirlsLove"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("GirlsLove"));

            if (TagGore == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Gore"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Gore"));

            if (TagGyaru == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Gyaru"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Gyaru"));

            if (TagHarem == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Harem"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Harem"));

            if (TagHistorical == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Historical"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Historical"));

            if (TagHorror == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Horror"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Horror"));

            if (TagIncest == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Incest"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Incest"));

            if (TagIsekai == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Isekai"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Isekai"));

            if (TagLoli == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Loli"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Loli"));

            if (TagLongStrip == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("LongStrip"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("LongStrip"));

            if (TagMafia == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Mafia"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Mafia"));

            if (TagMagic == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Magic"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Magic"));

            if (TagMagicalGirls == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("MagicalGirls"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("MagicalGirls"));

            if (TagMartialArts == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("MartialArts"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("MartialArts"));

            if (TagMecha == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Mecha"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Mecha"));

            if (TagMedical == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Medical"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Medical"));

            if (TagMilitary == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Military"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Military"));

            if (TagMonsterGirls == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("MonsterGirls"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("MonsterGirls"));

            if (TagMonsters == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Monsters"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Monsters"));

            if (TagMusic == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Music"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Music"));

            if (TagMystery == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Mystery"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Mystery"));

            if (TagNinja == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Ninja"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Ninja"));

            if (TagOfficeWorkers == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("OfficeWorkers"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("OfficeWorkers"));

            if (TagOfficialColored == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("OfficialColored"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("OfficialColored"));

            if (TagOneshot == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Oneshot"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Oneshot"));

            if (TagPhilosophical == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Philosophical"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Philosophical"));

            if (TagPolice == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Police"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Police"));

            if (TagPostApocalyptic == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("PostApocalyptic"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("PostApocalyptic"));

            if (TagPsychological == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Psychological"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Psychological"));

            if (TagReincarnation == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Reincarnation"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Reincarnation"));

            if (TagReverseHarem == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("ReverseHarem"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("ReverseHarem"));

            if (TagRomance == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Romance"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Romance"));

            if (TagSamurai == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Samurai"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Samurai"));

            if (TagSchoolLife == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("SchoolLife"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("SchoolLife"));

            if (TagSciFi == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("SciFi"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("SciFi"));

            if (TagSexualViolence == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("SexualViolence"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("SexualViolence"));

            if (TagShota == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Shota"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Shota"));

            if (TagSliceofLife == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("SliceofLife"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("SliceofLife"));

            if (TagSports == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Sports"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Sports"));

            if (TagSuperhero == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Superhero"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Superhero"));

            if (TagSupernatural == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Supernatural"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Supernatural"));

            if (TagSurvival == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Survival"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Survival"));

            if (TagThriller == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Thriller"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Thriller"));

            if (TagTimeTravel == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("TimeTravel"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("TimeTravel"));

            if (TagTragedy == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Tragedy"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Tragedy"));

            if (TagTraditionalGames == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("TraditionalGames"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("TraditionalGames"));

            if (TagUserCreated == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("UserCreated"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("UserCreated"));

            if (TagVampires == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Vampires"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Vampires"));

            if (TagVideoGames == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("VideoGames"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("VideoGames"));

            if (TagVillainess == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Villainess"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Villainess"));

            if (TagVirtualReality == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("VirtualReality"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("VirtualReality"));

            if (TagWebComic == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("WebComic"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("WebComic"));

            if (TagWuxia == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Wuxia"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Wuxia"));

            if (TagZombies == true)
                _parametersParams.Add("includedTags[]", Helper.ConvertTagToUuid("Zombies"));
            else if (TagAction == null)
                _parametersParams.Add("excludedTags[]", Helper.ConvertTagToUuid("Zombies"));
        }

        #endregion

        public QueryParameters Build()
        {
            _parametersParams = new QueryParameters();

            _parametersParams.Add("offset", Offset.ToString());
            _parametersParams.Add("limit", Limit.ToString());

            BuildTitle();
            BuildOriginalLanguage();
            BuildDemographic();
            BuldContentRating();
            BuildStatus();
            BuildTagModes();
            BuildTags();

            return _parametersParams;
        }

        public void SetTagByName(string chipText)
        {
            if (chipText.Equals("Comedy"))
            {
                TagComedy = true;
            }
        }
    }

    public enum SortBy
    {
        Relevance,
        LatestUploadedChapter,
        Title,
        CreatedAt,
        FollowedCount,
        UpdatedAt,
        Year,
    }

    public enum TagMode
    {
        And,
        Or
    }
}