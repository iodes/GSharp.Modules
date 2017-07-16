using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using L2DLib.Framework;
using L2DLib.Utility;
using System;

namespace GSharp.Modules.Live2D
{
    /// <summary>
    /// GLive2D.xaml에 대한 상호 작용 논리
    /// </summary>
    [GView("캐릭터 상자")]
    public partial class GLive2D : GView
    {
        #region 객체
        private L2DModel model;

        private int backRnd = 0;
        private Random random = new Random();
        #endregion

        #region 내부 함수
        private L2DMotion GetRandomMotion(L2DMotion[] target)
        {
            int rnd = random.Next(0, target.Length);
            while (rnd == backRnd)
            {
                rnd = random.Next(0, target.Length);
            }
            backRnd = rnd;

            return target[rnd];
        }
        #endregion

        [GControl(isTranslated: true)]
        [GTranslation("모델", Locale.KO_KR)]
        [GTranslation("モデル", Locale.JA_JP)]
        [GTranslation("Model", Locale.EN_US)]
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;

                model?.Dispose();
                model = L2DFunctions.LoadModel(_Path);
                model.UseBreath = true;
                model.UseEyeBlink = true;

                ContentView.Model = model;
            }
        }
        private string _Path;

        [GControl(isTranslated: true)]
        [GTranslation("모션", Locale.KO_KR)]
        [GTranslation("モーション", Locale.JA_JP)]
        [GTranslation("Motion", Locale.EN_US)]
        public GL2DMotion Motion
        {
            get
            {
                return _Motion;
            }
            set
            {
                _Motion = value;

                switch (_Motion)
                {
                    case GL2DMotion.IDLE:
                        GetRandomMotion(model?.Motion["idle"]).StartMotion();
                        break;

                    case GL2DMotion.TAP_BODY:
                        GetRandomMotion(model?.Motion["tap_body"]).StartMotion();
                        break;

                    case GL2DMotion.PINCH_IN:
                        GetRandomMotion(model?.Motion["pinch_in"]).StartMotion();
                        break;

                    case GL2DMotion.PINCH_OUT:
                        GetRandomMotion(model?.Motion["pinch_out"]).StartMotion();
                        break;

                    case GL2DMotion.SHAKE:
                        GetRandomMotion(model?.Motion["shake"]).StartMotion();
                        break;

                    case GL2DMotion.FLICK_HEAD:
                        GetRandomMotion(model?.Motion["flick_head"]).StartMotion();
                        break;
                }
            }
        }
        private GL2DMotion _Motion;

        [GCommand(isTranslated: true)]
        [GTranslation("모션 얼거형", Locale.KO_KR)]
        [GTranslation("モーション列挙", Locale.JA_JP)]
        [GTranslation("Motion Enum", Locale.EN_US)]
        public enum GL2DMotion
        {
            [GField("대기 모션")]
            IDLE,
            [GField("기본 모션")]
            TAP_BODY,
            [GField("확대 모션")]
            PINCH_IN,
            [GField("축소 모션")]
            PINCH_OUT,
            [GField("흔들기 모션")]
            SHAKE,
            [GField("머리 흔들기 모션")]
            FLICK_HEAD
        }

        public GLive2D()
        {
            InitializeComponent();
        }
    }
}
