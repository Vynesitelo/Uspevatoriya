using System;

namespace Успеватория
{
    public static class storeUserData
    {
        public static event Action<int> VariableChanged;
        public static event Action<int> VariableChangedBool;

        public static int id = 0;
        public static int idRole;
        public static int idSelectedUserSidePanel;
        public static int idSelectedGroupSidePanel;
        public static int sortUser = 1;
        private static int _x;
        public static int x
        {
            get { return _x; }
            set
            {
                _x = value;
                VariableChanged?.Invoke(value);
            }
        }
        private static int _isVisivle;
        public static int IsVisible
        {
            get { return _isVisivle; }
            set
            {
                _isVisivle = value;
                VariableChangedBool?.Invoke(value);
            }
        }
        public static bool _isAdminSelected;
        public static bool _isParentSelected;
        public static bool _isTeacherSelected;
        public static bool _isStudentSelected;
    }
}
